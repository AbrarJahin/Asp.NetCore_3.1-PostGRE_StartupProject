using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System.Net.Mail;
using System;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace StartupProject_Asp.NetCore_PostGRE.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<User> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            //[EmailAddress]
            [Display(Name = "Email / Username")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                string userName = Input.Email;
                if (IsValidEmail(Input.Email))
                {
                    User potentialUser = await _userManager.FindByEmailAsync(Input.Email.Normalize());
                    if (potentialUser != null)
                    {
                        userName = potentialUser.UserName;
                    }
                }
                User user = await _userManager.FindByNameAsync(userName.Normalize());
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Username or email not found");
                    return Page();
                }
                else if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Email Not Verified");
                    return Page();
                }
                SignInResult result = await _signInManager.PasswordSignInAsync(
                    user,
                    Input.Password,
                    Input.RememberMe,
                    lockoutOnFailure: true
                );
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                else if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else if (result.IsNotAllowed)
                {
                    _logger.LogWarning("User account Not Allowed");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            ModelState.AddModelError(string.Empty, "Something Wrong");
            return Page();
        }
    }
}

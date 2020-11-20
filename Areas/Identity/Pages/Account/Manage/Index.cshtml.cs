using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;

namespace StartupProject_Asp.NetCore_PostGRE.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public string UserNameChangeLimitMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Username")]
            public string Username { get; set; }
            [Required(ErrorMessage = "You must provide your phone number")]
            [Display(Name = "Phone Number")]
            [DataType(DataType.PhoneNumber)]
            [StringLength(15, MinimumLength = 11)]
            //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            [RegularExpression(@"^[0][1][3-9][0-9]{8}$", ErrorMessage = "Not a valid Banagladeshi mobile phone number without country code")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Profile Picture")]
            public byte[] ProfilePicture { get; set; }
            public int UsernameChangeLimit { get; internal set; }
        }

        private async Task LoadAsync(User user)
        {
            string phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            Username = await _userManager.GetUserNameAsync(user);
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicture,
                UsernameChangeLimit = user.UsernameChangeLimit
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            UserNameChangeLimitMessage = $"You can change your username {user.UsernameChangeLimit} more time(s).";
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            string phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            bool isUpdated = false;
            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
                isUpdated = true;
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
                isUpdated = true;
            }
            if (Input.PhoneNumber != phoneNumber)
            {
                user.PhoneNumber = Input.PhoneNumber;
                user.PhoneNumberConfirmed = false;
                isUpdated = true;
                //IdentityResult setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            }
            if (Input.Username != user.UserName && user.UsernameChangeLimit > 0)
            {
                User userNameExists = await _userManager.FindByNameAsync(Input.Username);
                if (userNameExists != null)
                {
                    StatusMessage = "User name already taken. Select a different username.";
                    //return RedirectToPage();
                }
                else
                {
                    user.UsernameChangeLimit -= 1;
                    user.UserName = Input.Username;
                    isUpdated = true;
                }
            }
            else if(Input.Username != user.UserName && user.UsernameChangeLimit <= 0)
            {
                StatusMessage = "Username change limit is exceeded";
            }
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }
            if (isUpdated)
            {
                IdentityResult setPhoneResult = await _userManager.UpdateAsync(user);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update user.";
                    return RedirectToPage();
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

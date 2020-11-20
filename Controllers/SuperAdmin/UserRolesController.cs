using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Attributes;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using StartupProject_Asp.NetCore_PostGRE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Controllers.SuperAdmin
{
    [AuthorizeRoles(ERole.SuperAdmin)]
    public class UserRolesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public UserRolesController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<User> users = await _userManager.Users.ToListAsync();
            List<UserRolesViewModel> userRolesViewModel = new List<UserRolesViewModel>();
            foreach (User user in users)
            {
                UserRolesViewModel thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }
        private async Task<List<string>> GetUserRoles(User user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}

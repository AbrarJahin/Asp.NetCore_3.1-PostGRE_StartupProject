using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Attributes;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Controllers.SuperAdmin
{
    [AuthorizeRoles(ERole.SuperAdmin)]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleManagerController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                //await _roleManager.CreateAsync(new Role(roleName.Trim()));
                await _roleManager.CreateAsync(new Role {
                    Name = roleName.Trim(),
                    Description = "Added From Admin"
                });
            }
            return RedirectToAction("Index");
        }
    }
}

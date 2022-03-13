using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P512FiorelloBack.Areas.Dashboard.ViewModels;
using P512FiorelloBack.Constants;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = RoleConstants.Admin+","+RoleConstants.Moderator)]
    public class UserController : Controller
    {

        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(AppDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _dbContext.Users.ToListAsync();
            List<UserVm> userList = new List<UserVm>();

            foreach (var user in users)
            {
                userList.Add(new UserVm
                {
                    Id = user.Id,
                    Fullname = user.FullName,
                    Username = user.UserName,
                    Roles = string.Join(", ", (await _userManager.GetRolesAsync(user))),
                    IsActive = user.IsActive
                });
            }

            return View(userList);
        }

        public async Task<IActionResult> GetRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var roles = await _userManager.GetRolesAsync(user);

            ViewBag.Name = user.FullName;
            ViewBag.UserId = user.Id;
            return View(roles);
        }

        public async Task<IActionResult> RemoveRole(string id, string roleName)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.RemoveFromRoleAsync(user, roleName);

            return RedirectToAction(nameof(GetRoles), new { user.Id });
        }

        public async Task<IActionResult> AddRole(string id)
        {
            var roles = await _dbContext.Roles.Select(r => r.Name).ToListAsync();

            AddRoleVm model = new AddRoleVm
            {
                UserId = id,
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string id, AddRoleVm model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (!ModelState.IsValid) return View(model);

            await _userManager.AddToRoleAsync(user, model.RoleName);

            return RedirectToAction(nameof(GetRoles), new { id });

        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            ViewBag.FullName = user.FullName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordVm model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (!ModelState.IsValid) return View();

            if(!await _userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                ModelState.AddModelError(nameof(ChangePasswordVm.OldPassword), "Old Password is not correct");
                return View();
            }

            var idResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!idResult.Succeeded)
            {
                foreach (var error in idResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> ToggleBlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = !user.IsActive;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }



    }
}

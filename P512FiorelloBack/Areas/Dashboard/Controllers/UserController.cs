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
                    Roles = string.Join(", ", (await _userManager.GetRolesAsync(user)))
                });
            }

            return View(userList);
        }
    }
}

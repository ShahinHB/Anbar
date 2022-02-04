using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Optima_Anbar.Data;
using Optima_Anbar.Models;
using Optima_Anbar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optima_Anbar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(AppDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            VmUserRole model = new VmUserRole();
            model.CustomUsers = _context.CustomUsers.ToList();
            model.Roles = _context.Roles.ToList();
            model.UserRoles = _context.UserRoles.ToList();
            return View(model);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(VmUser model)
        {
            if (ModelState.IsValid)
            {
                CustomUser newUser = new CustomUser()
                {
                    UserName = model.UserName,
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult UpdateUser(string id)
        {
            CustomUser user = _context.CustomUsers.Find(id);
            ViewBag.Roles = _context.Roles.ToList();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(CustomUser model)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = _context.CustomUsers.Find(model.Id);
                user.UserName = model.UserName;

                IdentityUserRole<string> userRole = _context.UserRoles.FirstOrDefault(u => u.UserId == model.Id);
                if (userRole != null)
                {
                    string oldRole = _context.Roles.Find(userRole.RoleId).Name;
                    await _userManager.RemoveFromRoleAsync(user, oldRole);
                }

                IdentityRole selectedRole = _context.Roles.Find(model.RoleId);

                await _userManager.AddToRoleAsync(user, selectedRole.Name);
                _context.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }

        public IActionResult Roles()
        {
            List<IdentityRole> roles = _context.Roles.ToList();
            return View(roles);
        }


        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(IdentityRole model)
        {
            await _roleManager.CreateAsync(model);
            return RedirectToAction("Roles");
        }

        public IActionResult DeleteUser(int id)
        {

            CustomUser user = _context.CustomUsers.Find(id);

            _context.CustomUsers.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

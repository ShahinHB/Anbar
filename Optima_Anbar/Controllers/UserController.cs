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
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            List<CustomUser> model = _context.CustomUsers.ToList();
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
        
    }
}

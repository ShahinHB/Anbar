using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optima_Anbar.Data;
using Optima_Anbar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optima_Anbar.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
            List<Product> model = _context.Products.ToList();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                model.AddingDate = DateTime.Now;
                model.Profit = model.Quantity * (model.SalePrice - model.BuyingPrice);              
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "ERROR");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            return View(_context.Products.Find(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(Product model)
        {
            if (ModelState.IsValid)
            {
                model.Profit = model.Quantity * (model.SalePrice - model.BuyingPrice);
                _context.Products.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            Product product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

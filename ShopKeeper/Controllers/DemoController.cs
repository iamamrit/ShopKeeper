using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopKeeper.Data;
using ShopKeeper.Migrations;
using ShopKeeper.Models;

namespace ShopKeeper.Controllers
{
    public class DemoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DemoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult DemoForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DemoForm([Bind("FirstName,LastName")] DemoModel demo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demo);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DemoForm));
            }
            return View(demo);
        }

    }
}
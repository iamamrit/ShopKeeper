using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopKeeper.Data;
using ShopKeeper.Models;

namespace ShopKeeper.Controllers
{
   
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Adding Items of Shop
        [Authorize]
        public IActionResult AddItems()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItems([Bind("ItemId,SerialNumber,ItemName,TotalItem,PricePerItem")] Item item)
            {
            if (ModelState.IsValid)
            {
                _context.Add(item);
              
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddItems));
            }
            return View(item);
            }
        // GET: Items
        [AllowAnonymous]
        public async Task<IActionResult> ViewItems()
        {
            return View(await _context.Item.ToListAsync());
        }

        public async Task<IActionResult> SellItems()
        {
            //To Select Specified Column From Databse.

              var NameList = _context.Item.Select(x => new {x.ItemName});
              ViewBag.NL = NameList;
            //var PriceList = _context.Item.Select(x => new { x.PricePerItem });
            //  ViewBag.PPI = PriceList;             
            // return View();

            return View(await _context.Item.ToListAsync());


        }






    }
}
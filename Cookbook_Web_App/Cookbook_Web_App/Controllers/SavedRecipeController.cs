using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Controllers
{
    public class SavedRecipeController : Controller  
    {
        private readonly CookbookDbContext _context;

        public SavedRecipeController(CookbookDbContext context)
        {
            _context = context;
        }

        //Get SavedRecipe
        public async Task<IActionResult> Index(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var user = await _context.SavedRecipe.FirstOrDefault(s => s.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);          
        }

        //Create SavedRecipe
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public async IActionResult Create([Bind("ID,APIReference")] SavedRecipe savedRecipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savedRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(savedRecipe);
        }

    }
}

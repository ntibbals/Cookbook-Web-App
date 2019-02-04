using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;

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
        public IActionResult Index(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            return View(savedRecipe);
        }

        //Create SavedRecipe
    }
}

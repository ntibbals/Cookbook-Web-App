using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Cookbook_Web_App.Models.Interfaces;
using Cookbook_Web_App.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearch _context;

        public SearchController(ISearch context)
        {
            _context = context;
        }

        static HttpClient client = new HttpClient();


        public async Task<IActionResult> Index(string searchRecipes)
        {

            var values = await _context.GetRecipesAsync();
                if (String.IsNullOrEmpty(searchRecipes))
                {
                    return View(values);
                }
            
            var val = values.Where(r => r.Name.ToLower().Contains(searchRecipes.ToLower()));
            
            return View(val);
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.GetRecipe(id));
            
        }

        public async Task<IActionResult> Save([Bind("SavedRecipeID,UserID,APIReference,Name")]int id, string name)
        {
            //if (id != null)
            //{
            //    return NotFound();
            //}
            var userName = HttpContext.Session.GetString("UserName");
            if (userName == null)
            {
                return RedirectToAction("Create", "User");
            }
            //HttpContext.Session.SetString("UserName", user.UserName);
            await _context.SaveRecipe(id, userName, name);
            return RedirectToAction("Index", "SavedRecipe");
        }

    }
}

using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index()
        {
            var name = HttpContext.Session.GetString("UserName");
            User user = _context.User.FirstOrDefault(u => u.UserName == name);
            var recipes = await _context.SavedRecipe.ToListAsync();
            var userRecipes = recipes.Where(r => r.UserID == user.ID);
            return View(userRecipes);
        }

        //Get SavedRecipe
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var savedRecipe = await _context.SavedRecipe
                .FirstOrDefaultAsync(r => r.SavedRecipeID == id);
            if (savedRecipe == null)
            {
                return NotFound();
            }

            return View(savedRecipe);
        }

        //Create SavedRecipe
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Create([Bind("SavedRecipeID,UserID,APIReference,Name")] SavedRecipe savedRecipe)
        {
            var name = HttpContext.Session.GetString("UserName");
            User user = _context.User.FirstOrDefault(u => u.UserName == name);
            if (ModelState.IsValid)
            {
                _context.Add(savedRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(savedRecipe);
        }

        //Edit SavedRecipe
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedRecipe = await _context.SavedRecipe.FindAsync(id);
            if (savedRecipe == null)
            {
                return NotFound();
            }
            return View(savedRecipe);
        }

        //Post: Edit SavedRecipe
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("SavedRecipeID,UserID,APIReference,Name")] SavedRecipe savedRecipe)
        {
            if (id != savedRecipe.SavedRecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savedRecipe);
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    if (!SavedRecipeExists(savedRecipe.SavedRecipeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(savedRecipe);
        }

        //Get Delete SavedRecipe
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedRecipe = await _context.SavedRecipe
                .FirstOrDefaultAsync(r => r.SavedRecipeID == id);
            if (savedRecipe == null)
            {
                return NotFound();
            }

            return View(savedRecipe);
        }

        //Delete SavedRecipe
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var savedRecipe = await _context.SavedRecipe.FirstAsync(s => s.SavedRecipeID == id);
            _context.SavedRecipe.Remove(savedRecipe);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool SavedRecipeExists(int id)
        {
            return _context.SavedRecipe.Any(s => s.SavedRecipeID == id);
        }
    }
}
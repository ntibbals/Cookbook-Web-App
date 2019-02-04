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

            var savedRecipe = await _context.SavedRecipe.FirstOrDefault(s => s.ID == id);
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

        //Edit SavedRecipe
        public async IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedRecipe = await _context.SavedRecipe.FirstOrDefault(s => s.ID == id);
            if (savedRecipe == null)
            {
                return NotFound();
            }

            return View(SavedRecipe);
        }

        //Post: Edit SavedRecipe
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,APIReference")] SavedRecipe savedRecipe)
        {
            if (id != savedRecipe.ID)
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
                    if (!SavedRecipeExists(savedRecipe.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            return View(savedRecipe);
        }

        //Get Delete SavedRecipe
        public async Task<IActionResult> Delete(int id)
        {
            var savedRecipe = _context.SavedRecipe.FirstOrDefault(s => s.ID == id);
            if (savedRecipe == null)
            {
                return NotFound();
            }

            return View(SavedRecipe);
        }

        //Delete SavedRecipe
        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var savedRecipe = _context.SavedRecipe.FirstOrDefault(s => s.ID == id);
            _context.SavedRecipe.Remove(savedRecipe);

            await _context.SaveChangesAsync();
            return View(); 
        }


        private bool SavedRecipeExists(int id)
        {
            return _context.SavedRecipe.Any(s => s.ID == id);
        }
    }
}
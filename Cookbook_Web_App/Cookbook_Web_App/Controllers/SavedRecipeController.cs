using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Controllers
{
    public class SavedRecipeController : Controller
    {
        private readonly CookbookDbContext _context;

        static HttpClient client = new HttpClient();


        public SavedRecipeController(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string userName)
        {
            if (userName == null)
            {
                var name = HttpContext.Session.GetString("UserName");
                User user = _context.User.FirstOrDefault(u => u.UserName == name);
                var recipes = await _context.SavedRecipe.ToListAsync();
                var userRecipes = recipes.Where(r => r.UserID == user.ID);
                return View(userRecipes);
            }
            else
            {
                var name = userName;
                User user = _context.User.FirstOrDefault(u => u.UserName == name);
                var recipes = await _context.SavedRecipe.ToListAsync();
                var userRecipes = recipes.Where(r => r.UserID == user.ID);
                return View(userRecipes);
            }
        }
        //Get SavedRecipe
        public async Task<IActionResult> Details(int? id)
        {
            Recipe recipe = new Recipe();
            IEnumerable<Instructions> instructions = null;
            IEnumerable<RecipeIngredients> recipeIngredients = null;
            IEnumerable<Ingredients> ingredients = null;
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage responseRecipe = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Recipes/{id}");
            HttpResponseMessage responseInstructions = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Instructions");
            HttpResponseMessage responseIngredients = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/RecipeIngredients");
            HttpResponseMessage responseBaseIngredients = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Ingredients");

            recipe = await responseRecipe.Content.ReadAsAsync<Recipe>();
            instructions = await responseInstructions.Content.ReadAsAsync<IEnumerable<Instructions>>();
            recipeIngredients = await responseIngredients.Content.ReadAsAsync<IEnumerable<RecipeIngredients>>();
            var ingredientQuery = recipeIngredients.Where(r => r.recipeID == id);

            ingredients = await responseBaseIngredients.Content.ReadAsAsync<IEnumerable<Ingredients>>();
            foreach (var ing in ingredientQuery)
            {
                foreach (var item in ingredients)
                {
                    if(item.ID == ing.ingredientsID)
                    {
                        item.Quantity = ing.quantity;
                        item.RecipeID = ing.recipeID;
                    }
                }
            }
            recipe.Ingredients = ingredients.Where(ri => ri.RecipeID == id);
            recipe.Instructions = instructions.Where(ri => ri.RecipeId== id);

            return View(recipe);
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
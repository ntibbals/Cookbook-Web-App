using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Cookbook_Web_App.Models.Interfaces;
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
        private readonly ISavedRecipe _context;

        static HttpClient client = new HttpClient();


        public SavedRecipeController(ISavedRecipe context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string userName)
        {
            if (userName == null)
            {
                var name = HttpContext.Session.GetString("UserName");
                User user = await _context.GetUser(name);
                if (user == null)
                {
                    return RedirectToAction("Index", "User");
                }
                var recipes = await _context.GetSavedRecipes();
                var userRecipes = recipes.Where(r => r.UserID == user.ID);
                return View(userRecipes);
            }
            else
            {
                var name = userName;
                User user = await _context.GetUser(userName);
                var recipes = await _context.GetSavedRecipes();
                var userRecipes = recipes.Where(r => r.UserID == user.ID);
                return View(userRecipes);
            }
        }

        //Get SavedRecipe
        public async Task<IActionResult> Details(int id)
        {
            SavedRecipe savedRecipe = await _context.GetSavedRecipe(id);
            int iD = savedRecipe.APIReference;

            Recipe recipe = new Recipe();
            IEnumerable<Instructions> instructions = null;
            IEnumerable<RecipeIngredients> recipeIngredients = null;
            IEnumerable<Ingredients> ingredients = null;


            HttpResponseMessage responseRecipe = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Recipes/{iD}");
            HttpResponseMessage responseInstructions = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Instructions");
            HttpResponseMessage responseIngredients = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/RecipeIngredients");
            HttpResponseMessage responseBaseIngredients = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Ingredients");

            recipe = await responseRecipe.Content.ReadAsAsync<Recipe>();
            instructions = await responseInstructions.Content.ReadAsAsync<IEnumerable<Instructions>>();
            recipeIngredients = await responseIngredients.Content.ReadAsAsync<IEnumerable<RecipeIngredients>>();
            var ingredientQuery = recipeIngredients.Where(r => r.recipeID == iD);

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
            recipe.Ingredients = ingredients.Where(ri => ri.RecipeID == iD);
            recipe.Instructions = instructions.Where(ri => ri.RecipeId== iD);
            HttpContext.Session.SetInt32("CommentsID", id);
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
            User user = await _context.GetUser(name);
            if (ModelState.IsValid)
            {
                await _context.CreateRecipe(savedRecipe);
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

            var savedRecipe = await _context.GetSavedRecipe(id);
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
 
            await _context.DeleteSavedRecipe(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RedirectToDetails(int id)
        {
            return RedirectToAction("View", "Comments");
        }

        private bool SavedRecipeExists(int id)
        {
            return _context.SavedRecipeExists(id);
        }
    }
}
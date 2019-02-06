using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
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
        private readonly CookbookDbContext _context;

        static HttpClient client = new HttpClient();

        public SearchController(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchRecipes)
        {
            IEnumerable<Recipe> values = null;
            //GetAsync takes in a string path. To get the API connection to work, run the API and replace this local host with your local host(keep api/values)
            //To test that this works, got to Search/Index
            //TODO: After deployment, change localhost to API path
            HttpResponseMessage response = await client.GetAsync("https://cookbookapi20190205105239.azurewebsites.net/api/Recipes");
            if (response.IsSuccessStatusCode)
            {
                values = await response.Content.ReadAsAsync<IEnumerable<Recipe>>();
                values = values.Where(r => r.Name.ToLower().Contains(searchRecipes.ToLower())).ToList();
            }

            return View(values);
        }

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
            var recipeIngredients2 = recipeIngredients.Where(i => i.recipeID == id);

            ingredients = await responseBaseIngredients.Content.ReadAsAsync<IEnumerable<Ingredients>>();

            foreach (var ing in recipeIngredients2)
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

            recipe.Ingredients = ingredients.Where(i => i.RecipeID == id);


            recipe.Instructions = instructions.Where(i => i.RecipeId == id);
            return View(recipe);
        }

        public async Task<IActionResult> Save([Bind("SavedRecipeID,UserID,APIReference,Name")]int id, string name)
        {
            //if (id != null)
            //{
            //    return NotFound();
            //}
            var userName = HttpContext.Session.GetString("UserName");
            User user = await _context.User.FirstOrDefaultAsync(u => u.UserName == userName);

            SavedRecipe saveRecipe = new SavedRecipe();
            saveRecipe.UserID = user.ID;
            saveRecipe.APIReference = id;
            saveRecipe.Name = name;

            _context.Add(saveRecipe);
            await _context.SaveChangesAsync();
            //HttpContext.Session.SetString("UserName", user.UserName);
            return RedirectToAction("Index", "SavedRecipe");
        }

    }
}

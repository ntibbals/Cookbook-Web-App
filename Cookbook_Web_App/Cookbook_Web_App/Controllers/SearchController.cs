using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Cookbook_Web_App.Controllers
{
    public class SearchController : Controller
    {
        private readonly CookbookDbContext _context;

        static HttpClient client = new HttpClient();
        public static string Path = "https://cookbookapi20190205105239.azurewebsites.net/api/values";
        public SearchController(CookbookDbContext context)
        {
            _context = context;
        }

            public async Task<IEnumerable<IActionResult>> Index()
        {
            IEnumerable<Recipe> recipe = null;
            HttpResponseMessage response = await client.GetAsync(Path);
            if(response.IsSuccessStatusCode)
            {
                recipe = await response.Content.ReadAsAsync<IEnumerable<Recipe>>();
            }
            return View(recipe);

        }



        }
}

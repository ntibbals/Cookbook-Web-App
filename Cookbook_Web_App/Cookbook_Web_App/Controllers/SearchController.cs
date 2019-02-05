using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            string [] values = null;
            //GetAsync takes in a string path. To get the API connection to work, run the API and replace this local host with your local host(keep api/values)
            //To test that this works, got to Search/Index
            //TODO: After deployment, change localhost to API path
            HttpResponseMessage response = await client.GetAsync("http://localhost:50170/api/values");
            if (response.IsSuccessStatusCode)
            {
                values = await response.Content.ReadAsAsync<string[]>();

            }

            return View(values);
        }
    }
}

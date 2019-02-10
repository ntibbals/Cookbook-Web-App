using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook_Web_App.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns homepage view
        /// </summary>
        /// <returns>View(Index)</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
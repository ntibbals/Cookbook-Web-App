using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cookbook_Web_App.Controllers
{
    public class UserController : Controller
    {
        private readonly CookbookDbContext _context;

        public UserController(CookbookDbContext context)
        {
            _context = context;
        }
        //Get LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userInput)
        {

            User user = _context.User.FirstOrDefault(u => u.UserName == userInput);
            if (user != null)
            {

                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction(nameof(Index), user);
            }
            else
            {
                return RedirectToAction(nameof(Create));
            }

        }
        //Get User
        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString("UserName");
            User user = _context.User.FirstOrDefault(u => u.UserName == name);

            if (user == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(user);
        }

        //Get: Create User
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: create user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction(nameof(Index), user);
            }

            return RedirectToAction("Index");
        }

        //Get: Edit user
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.User.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Post: Edit user
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            return RedirectToAction(nameof(Index), user);
        }

        //Get Delete user
        public async Task<IActionResult> Delete(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Post Delete user
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.ID == id);

            var recipes = await _context.SavedRecipe.ToListAsync();
            var userRecipes = recipes.Where(r => r.UserID == id);
            var comments = await _context.Comments.ToListAsync();
            foreach (var userRecipe in userRecipes)
            {
                var recipeComments = comments.Where(c => c.SavedRecipeID == userRecipe.SavedRecipeID);
                foreach (var recipeComment in recipeComments)
                {
                    _context.Comments.Remove(recipeComment);
                }
                _context.SavedRecipe.Remove(userRecipe);
            }
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
            //TODO Redirect to home page instead of dead index page
        }

        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home"); //TODO redirect to homepage
        }


        private bool UserExists(int id)
        {
            return _context.User.Any(u => u.ID == id);
        }
    }
}
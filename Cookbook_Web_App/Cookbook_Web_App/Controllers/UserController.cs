using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Cookbook_Web_App.Models.Interfaces;

namespace Cookbook_Web_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _context;

        public UserController(IUser context)
        {
            _context = context;
        }
        //Get LOGIN
        /// <summary>
        /// Get login page
        /// </summary>
        /// <returns>Returns View(Login)</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Post Login
        /// Processes Login, confirms user exists, starts session
        /// </summary>
        /// <param name="userInput">string</param>
        /// <returns>View(index)</returns>
        [HttpPost]
        public async Task<IActionResult> Login(string userInput)
        {

            var users = await _context.GetUsersAsync();
            var user = users.FirstOrDefault(u => u.UserName == userInput);
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
        /// <summary>
        /// Gets user information and user page
        /// </summary>
        /// <returns>View of user information</returns>
        public async  Task<IActionResult> Index()
        {
            var name = HttpContext.Session.GetString("UserName");
            var users = await _context.GetUsersAsync();
            User user = users.FirstOrDefault(u => u.UserName == name);

            if (user == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(user);
        }

        //Get: Create User
        /// <summary>
        /// Get's Create user view
        /// </summary>
        /// <returns>View(create)</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: create user
        /// <summary>
        /// Takes username input, checks that name is unique, and creates new user.
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>user profile view/View(Index)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                var users = await _context.GetUsersAsync();
                foreach (var u in users)
                {
                    if (u.UserName == user.UserName)
                    {                        
                        return RedirectToAction(nameof(Create2));
                    }
                }
                await _context.CreateUser(user);
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction(nameof(Index), user);
            }

            return RedirectToAction("Index");
        }

        //Get: Edit user
        /// <summary>
        /// Get edit user page by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>View(edit)</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users = await _context.GetUsersAsync();
            var user = users.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Post: Edit user
        /// <summary>
        /// Based on user input, changes username
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="user">User</param>
        /// <returns>User info/View(index)</returns>
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
                    await _context.UpdateUser(user);

                }
                catch (Exception)
                {
                    bool tester = await UserExistsAsync(user.ID);
                    if (!tester)
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
        /// <summary>
        /// Get delete page by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Delete page view</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var users = await _context.GetUsersAsync();
            var user = users.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Post Delete user
        /// <summary>
        /// Confirms delete and removes user from database by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Homepage view</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {

            await _context.DeleteUser(id);
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Ends session
        /// </summary>
        /// <returns>Homepage view</returns>
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Checks that user exists by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        private async Task<bool> UserExistsAsync(int id)
        {
            var users = await _context.GetUsersAsync();
            return users.Any(u => u.ID == id);
        }


        //--------------------------------------------//
        /// <summary>
        /// Second create method
        /// </summary>
        /// <returns>Create2 view</returns>
        //Get: Create User
        [HttpGet]
        public IActionResult Create2()
        {
            return View();
        }

        //POST: create user
        /// <summary>
        /// second create page if original user input was a duplicate
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("ID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                var users = await _context.GetUsersAsync();
                foreach (var u in users)
                {
                    if (u.UserName == user.UserName)
                    {
                        return RedirectToAction(nameof(Create2));
                    }
                }
                await _context.CreateUser(user);
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction(nameof(Index), user);
            }

            return RedirectToAction("Index");
        }
    }
}
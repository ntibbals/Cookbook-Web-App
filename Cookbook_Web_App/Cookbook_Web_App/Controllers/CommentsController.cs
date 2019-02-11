using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Cookbook_Web_App.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IComments _context;

        public CommentsController(IComments context)
        {
            _context = context;
        }

        /// <summary>
        /// Home page of comments model
        /// </summary>
        /// <returns>inddex view</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int? id = HttpContext.Session.GetInt32("CommentsID"); /// pull saved recipe id from session located in saved recipe controller, details method
            var allComments = await _context.GetComments();
            if (allComments == null)
            {
                return NotFound();
            }
            return View(allComments);
        }

        /********* Commented out to trouble shoot additional feature to insert user auth on comments index page************/
        //[HttpGet]
        //public async Task<IActionResult> Index(string userName)
        //{

        //        var name = HttpContext.Session.GetString("UserName");
        //        User user = await _context.GetUser(name);
        //        if (user == null)
        //        {
        //            return RedirectToAction("Index", "User");
        //        }
        //        int? id = HttpContext.Session.GetInt32("CommentsID");
        //        var allComments = await _context.GetComments();
        //        var comment = allComments.Where(co => co.SavedRecipeID == co.ID);
        //        if (comment == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(comment);


        //        //var name = userName;
        //        //User user = await _context.GetUser(name);
        //        //var allComments = await _context.GetComments();
        //        //var comment = allComments.FirstOrDefault(co => co.ID == user.ID);
        //        //return View(comment);


        //}
        /// <summary>
        /// Get Comments
        /// </summary>
        /// <param name="ID">comment ID</param>
        /// <returns>Comments</returns>
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var allComments = await _context.GetComments();
            if (allComments ==null)
            {
                return NotFound();
            }

            return View(allComments);
        }

        public async Task<IActionResult> View(int? id)
        {
            if (id == null)
            {
                id = HttpContext.Session.GetInt32("CommentsID");  /// pull saved recipe id from session located in saved recipe controller, details method
                if (id == null)
                {
                    return NotFound();
                }
            }
            var allComments = await _context.GetComments();
            var comment = allComments.Where(co => co.SavedRecipeID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        //Get: Create User
        public IActionResult Create(int? savedRecipeId, string name)
        {
            if (savedRecipeId == null)
            {
                savedRecipeId = HttpContext.Session.GetInt32("CommentsID");  /// pull saved recipe id from session located in saved recipe controller, details method
                name = HttpContext.Session.GetString("Name"); /// pull username from session located in saved recipe controller, details method
                if (savedRecipeId == null)
                {
                    return NotFound();
                }
            }
            return View();
        }
        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="comment">new comment</param>
        /// <returns>view</returns>
        [HttpPost]
        public  async Task<IActionResult> Create([Bind ("ID, SavedRecipeID, Comment, Name")] Comments comments )
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _context.CreateComment(comments);
                    return RedirectToAction(nameof(View));
                }
                return RedirectToAction(nameof(View));
            }
            catch (Exception)
            {
                return Redirect("https://http.cat/500");

            }
        }

        /// <summary>
        /// Find comment to edit
        /// </summary>
        /// <param name="id">comment id</param>
        /// <returns>comment view</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var allComments = await _context.GetComments();

            var comment = allComments.FirstOrDefault(co => co.ID == id);
            
            if(comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        /// <summary>
        /// Edit comment
        /// </summary>
        /// <param name="id">comment to edit</param>
        /// <param name="comments">comment object</param>
        /// <returns>view</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SavedRecipeID,Comment, Name")] Comments comments)
        {
            if(id != comments.ID)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {

                    await _context.GetComments(comments);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(View));
            }

            return RedirectToAction(nameof(View));
        }


        /// <summary>
        /// Delete lookup
        /// </summary>
        /// <param name="id">comment to delete</param>
        /// <returns>delete view</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var allComments = await _context.GetComments();
            var comment = allComments.FirstOrDefault(co => co.ID == id);

            if(comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        /// <summary>
        /// Confirm if user wants to delete comment
        /// </summary>
        /// <param name="id">id of comment to delte</param>
        /// <returns>index view</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var allComments = await _context.GetComments();
            var comment = allComments.FirstOrDefault(co => co.ID == id);

            await _context.Delete(comment.ID);

            return RedirectToAction(nameof(View));
        }

        /// <summary>
        /// Redirect to Create a Comment Page view, pulls in saved recipe id
        /// </summary>
        /// <param name="savedRecipeId">user saved recipe id</param>
        /// <param name="name">User name</param>
        /// <returns>Comment create page</returns>
        public IActionResult RedirectToDetails(int? savedRecipeId, string name)
        {
            if (savedRecipeId == null)
            {
                savedRecipeId = HttpContext.Session.GetInt32("CommentsID");  /// pull saved recipe id from session located in saved recipe controller, details method
                name = HttpContext.Session.GetString("Name");  /// pull username from session located in saved recipe controller, details method

                if (savedRecipeId == null)
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Create", "Comments", new { savedRecipeId, name });
        }

        /// <summary>
        /// Redirect to saved recipe details page
        /// </summary>
        /// <param name="id">recipe id</param>
        /// <param name="name">user name</param>
        /// <returns>saved recipe details page with id</returns>
        public IActionResult RedirectToSave(int? id, string name)
        {
            if (id == null)
            {
                id = HttpContext.Session.GetInt32("CommentsID");  /// pull saved recipe id from session located in saved recipe controller, details method
                name = HttpContext.Session.GetString("Name");  /// pull usernamefrom session located in saved recipe controller, details method

                if (id == null)
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Details", "SavedRecipe", new { id });
        }




    }
}

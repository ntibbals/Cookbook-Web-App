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


        //Get: Create User
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int? id = HttpContext.Session.GetInt32("CommentsID");
            var allComments = await _context.GetComments();
            if (allComments == null)
            {
                return NotFound();
            }
            return View(allComments);
        }
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
            var comment = allComments.FirstOrDefault(co => co.ID == id);
            if (comment ==null)
            {
                return NotFound();
            }

            return View(comment);
        }

        public async Task<IActionResult> View(int? id)
        {
            if (id == null)
            {
                id = HttpContext.Session.GetInt32("CommentsID");
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
                savedRecipeId = HttpContext.Session.GetInt32("CommentsID");
                name = HttpContext.Session.GetString("Name");
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

                    await _context.UpdateComment(comments);
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

        public IActionResult RedirectToDetails(int? savedRecipeId, string name)
        {
            if (savedRecipeId == null)
            {
                savedRecipeId = HttpContext.Session.GetInt32("CommentsID");
                name = HttpContext.Session.GetString("Name");

                if (savedRecipeId == null)
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Create", "Comments", new { savedRecipeId, name });
        }
        public IActionResult RedirectToSave(int? id, string name)
        {
            if (id == null)
            {
                id = HttpContext.Session.GetInt32("CommentsID");
                name = HttpContext.Session.GetString("Name");

                if (id == null)
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Details", "SavedRecipe", new { id });
        }




    }
}

using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
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
        private readonly CookbookDbContext _context;

        public CommentsController(CookbookDbContext context)
        {
            _context = context;
        }


        //Get: Create User
        [HttpGet]
        public IActionResult Index()
        {
            return View();
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

            var comment =  await _context.Comments.FirstOrDefaultAsync(co => co.ID == id);
            if (comment ==null)
            {
                return NotFound();
            }

            return View(comment);
        }


        //Get: Create User
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="comment">new comment</param>
        /// <returns>view</returns>
        [HttpPost]
        public  async Task<IActionResult> Create([Bind ("ID, SavedRecipeID, Comment")] Comments comments )
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.Add(comments);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(comments);
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

            var comment = await _context.Comments.FirstOrDefaultAsync(co => co.ID == id);
            
            if(User == null)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID, SavedRecipeID")] Comments comments)
        {
            if(id != comments.ID)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {

                    _context.Update(comments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(comments);
        }


        /// <summary>
        /// Delete lookup
        /// </summary>
        /// <param name="id">comment to delete</param>
        /// <returns>delete view</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(co => co.ID == id);

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
            var comment = await _context.Comments.FirstOrDefaultAsync(co => co.ID == id);

            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if comment exists
        /// </summary>
        /// <param name="id">comment id</param>
        /// <returns>comment</returns>
        private bool CommentExists(int id)
        {
            return _context.Comments.Any(co => co.ID == id);
        }





        
    }
}

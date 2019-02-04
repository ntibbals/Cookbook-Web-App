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

        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="comment">new comment</param>
        /// <returns>view</returns>
        [HttpPost]
        public  async Task<IActionResult> Create([Bind ("ID, SavedRecipeID")] Comments comments )
        {
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comments);
        }

        

        
    }
}

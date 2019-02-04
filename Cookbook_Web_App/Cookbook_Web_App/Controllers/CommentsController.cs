using Cookbook_Web_App.Data;
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
        public async Task<IActionResult> IndexAsync(int? id)
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
    }
}

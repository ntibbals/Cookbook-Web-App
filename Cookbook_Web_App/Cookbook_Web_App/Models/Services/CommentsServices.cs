using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Services
{
    public class CommentsServices : IComments
    {

        public CookbookDbContext _context { get; }

        public CommentsServices (CookbookDbContext context)
        {
            _context = context;
        }

        public async Task CreateComment(Comments comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(co => co.ID == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComment(Comments comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comments> GetSavedComments(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(co => co.SavedRecipeID == id);
        }

        public async Task<IEnumerable<Comments>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}

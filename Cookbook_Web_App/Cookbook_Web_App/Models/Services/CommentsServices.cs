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
        /// <summary>
        /// Adds a comment to the comment table
        /// </summary>
        /// <param name="comment">Comments</param>
        /// <returns>Task</returns>
        public async Task CreateComment(Comments comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes comment from comments table by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task Delete(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(co => co.ID == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Updates comment in comments table
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <returns>Task</returns>
        public async Task GetComments(Comments comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets comment based on ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Comment</returns>
        public async Task<Comments> GetSavedComments(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(co => co.SavedRecipeID == id);
        }
        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <returns>Task<Ienumerable<Comments>></returns>
        public async Task<IEnumerable<Comments>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }


        /// <summary>
        /// Gets user based on userName
        /// </summary>
        /// <param name="userName">String</param>
        /// <returns>user</returns>
        public async Task<User> GetUser(string userName)
        {

                User user = await _context.User.FirstOrDefaultAsync(u => u.UserName == userName);
                return user;

        }
    }
}

using Cookbook_Web_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Data
{
    public class CookbookDbContext : DbContext
    {

        public CookbookDbContext(DbContextOptions<CookbookDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// While creating model, able to set key creations, informaiton you need to know about while db is being constructed
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                  new User
                  {
                      ID = 33,
                      UserName = "Tom"
                  }
                  );
            modelBuilder.Entity<SavedRecipe>().HasData(
                  new SavedRecipe
                  {
                      SavedRecipeID = 11,
                      APIReference = 22,
                      Instructions = "Cook until you can't cook no mo",
                      comments = "This is so good",
                  }
                  );
        }

        public DbSet<Comments> Comments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SavedRecipe> SavedRecipe { get; set; }
    }
}

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
                    ID = 1,
                    UserName = "HoneyLavender37"

                },

                new User
                {
                    ID = 2,
                    UserName = "HappyDude123"

                },

                new User
                {
                    ID = 3,
                    UserName = "TacoGuy99"

                },

                new User
                {
                    ID = 4,
                    UserName = "CroissantBuns12"

                },

                new User
                {
                    ID = 5,
                    UserName = "Chicken4ever"

                },

                new User
                {
                    ID = 6,
                    UserName = "ILikeEggs"

                },

                new User
                {
                    ID = 7,
                    UserName = "MizzBakesStuff"

                },
                new User { 
                      ID = 33,
                      UserName = "Tom"
                  }
                  );
                  
            modelBuilder.Entity<SavedRecipe>().HasData(
                  new SavedRecipe
                  {
                      SavedRecipeID = 11,
                      APIReference = 22,
                  }
                  );
        }

        public DbSet<Comments> Comments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SavedRecipe> SavedRecipe { get; set; }
    }
}

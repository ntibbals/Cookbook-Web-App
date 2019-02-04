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

        }

        public DbSet<Comments> Comments { get; set; }
    }
}

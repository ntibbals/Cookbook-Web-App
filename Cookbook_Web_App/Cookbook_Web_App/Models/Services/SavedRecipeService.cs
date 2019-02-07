using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Services
{
    public class SavedRecipeService : ISavedRecipe
    {
        private CookbookDbContext _context { get; }

        public SavedRecipeService(CookbookDbContext context)
        {
            _context = context;
        }

        //create
    }
}

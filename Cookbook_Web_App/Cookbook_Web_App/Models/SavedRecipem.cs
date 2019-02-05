using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class SavedRecipe
    {
        public int SavedRecipeID { get; set; }
        public int APIReference { get; set; }

        //Navigation Properties
        public ICollection<Comments> Comments { get; set; }
        public User User { get; set; }
    }
}
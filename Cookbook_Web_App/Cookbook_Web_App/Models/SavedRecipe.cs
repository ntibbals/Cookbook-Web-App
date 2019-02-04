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

        public string Instructions { get; set; }
        public string Reviews { get; set; }
        public string comments { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<User> User { get; set; }
    }
}
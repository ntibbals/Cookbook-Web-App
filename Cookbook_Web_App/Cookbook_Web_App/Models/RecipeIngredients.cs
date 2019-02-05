using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class RecipeIngredients
    {
        public int recipeID { get; set; }
        public int ingredientsID { get; set; }
        public string quantity { get; set; }
    }
}

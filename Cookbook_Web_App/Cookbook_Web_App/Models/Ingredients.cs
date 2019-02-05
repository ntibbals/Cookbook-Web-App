using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class Ingredients
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public int RecipeID { get; set; }
    }
}

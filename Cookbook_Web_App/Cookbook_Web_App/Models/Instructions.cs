using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class Instructions
    {
        public int RecipeId { get; set; }
        public int stepNumberID { get; set; }
        public string action { get; set; }
    }

}

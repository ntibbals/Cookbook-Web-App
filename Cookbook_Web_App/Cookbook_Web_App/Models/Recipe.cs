using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Instructions { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
    }
}

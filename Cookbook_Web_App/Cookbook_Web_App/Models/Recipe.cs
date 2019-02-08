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
        public string ImageURL { get; set; }
        public IEnumerable<Comments> Comment { get; set; }
        public IEnumerable<Instructions> Instructions { get; set; }
        public IEnumerable<Ingredients> Ingredients { get; set; }
    }
}

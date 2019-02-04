using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class User
    {
        //PrimaryKey
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string UserName { get; set; }


        //Navigational Properties
        //public ICollection<SavedRecipe> SavedRecipe { get; set; } 
    }
}

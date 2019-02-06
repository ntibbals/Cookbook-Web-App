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

       
        [StringLength(25), Required(ErrorMessage ="Cannot be more than 25 characters")]
        public string UserName { get; set; }


        //Navigational Properties
        public ICollection<SavedRecipe> SavedRecipe { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public int SavedRecipeID { get; set; }
        [Required]
        [Column(TypeName = "StringLength(512)")]
        public string Comment { get; set; }
    }
}

﻿using System;
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
        public int APIReference { get; set; }
        [Column(TypeName ="varchar(max)")]
        [MaxLength]
        public string Comment { get; set; }
        public string Name { get; set; }
    }
}

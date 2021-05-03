using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarryBoats.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description of Product")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "It is part of a repair")]
        public Boolean IsARepair { get; set; }

    }
   
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarryBoats.Models
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext() : base("ProductDbContext")
        {

        }
            //public DbSet<Product> Products { get; set; }
    }
}
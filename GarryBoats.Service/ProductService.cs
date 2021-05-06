using GarryBoats.Data;
using GarryBoats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarryBoats.Service
{
    public class ProductService
    {
        private readonly Guid _userid;

        public bool CreateProduct(ProductCreate model)
        {
            var entity = new Product()
            {
                IsARepair = model.IsARepair,
                Description = model.Description,
                InventoryCount = model.InventoryCount,
                Name = model.Name,
                Price = model.Price,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}

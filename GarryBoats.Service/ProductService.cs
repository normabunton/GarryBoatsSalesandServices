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

        public ProductService(Guid userId)
        {
            _userid = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity = new Product()
            {
                ProductId = model.ProductId,
                IsARepair = model.IsARepair,
                Description = model.Description,
                InventoryCount = model.InventoryCount,
                Name = model.Name,
                Price = model.Price,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Where(e = e.UserId == _userid)
                        .Select(
                                e =>
                                    new ProductListItem
                                    {
                                        ProductId = e.ProductId,
                                        ProductName = e.ProductName,
                                        CreatedUtc = e.CreatedUtc
                                    }
                          );
                return query.ToArray();
            }
        }

    }
}

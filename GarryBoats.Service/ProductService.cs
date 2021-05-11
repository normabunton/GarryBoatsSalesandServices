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
                
                IsARepair = model.IsARepair,
                ProductDescription = model.Description,
                InventoryCount = model.InventoryCount,
                ProductName = model.Name,
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
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Products
                    .Single(e => e.ProductId == id);
                return new Models.ProductDetail
                {
                    ProductId = entity.ProductId,
                    ProductName = entity.ProductName,
                    ProductDescription = entity.ProductDescription,
                    Price = entity.Price,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        public bool UpdateProduct(ProductEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Products
                    .Single(e => e.userId == userId);

                entity.ProductName = Model.ProductName;
                entity.ProductDescription = Model.ProductDescription;
                entity.Price = Model.Price;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

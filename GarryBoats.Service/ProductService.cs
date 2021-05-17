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
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity = new Product
            {

                ProductName = model.Name,
                ProductDescription = model.Description,
                Price = model.Price,
                InventoryCount = model.InventoryCount,
                IsARepair = model.IsARepair,
                CreatedUtc = DateTimeOffset.Now,
                ModifiedUtc = null
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
                                        ProductDescription = e.ProductDescription,
                                        Price = e.Price,
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
                return new ProductDetail
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
                    .Single(e => e.ProductId == Model.ProductId);

                entity.ProductName = Model.ProductName;
                entity.ProductDescription = Model.ProductDescription;
                entity.Price = Model.Price;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Products
                    .Single(e => e.ProductId == productId);

                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

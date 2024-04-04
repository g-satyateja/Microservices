using CatalogService.Database;
using CatalogService.Database.Entities;
using CatalogService.Services.Interfaces;

namespace CatalogService.Services.Implementations
{
    public class ProductService : IProductService
    {
        AppDbContext _context;
        private readonly IConfiguration _config;

        public ProductService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
                _ = _context.Products.Remove(product);
        }

        public Product GetProduct(int id)
        {
            Product p = _context.Products.Find(id);
            if (p != null)
                return new Product
                {
                    Category = p.Category,
                    CategoryId = p.CategoryId,
                    CreatedDate = p.CreatedDate,
                    Description = p.Description,
                    ImageUrl = _config["ImageServer"] + p.ImageUrl,
                    Name = p.Name,
                    ProductId = p.ProductId,
                    UnitPrice = p.UnitPrice
                };
            return null;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Select(p => new Product
            {
                Category = p.Category,
                CategoryId = p.CategoryId,
                CreatedDate = p.CreatedDate,
                Description = p.Description,
                ImageUrl = _config["ImageServer"] + p.ImageUrl,
                Name = p.Name,
                ProductId = p.ProductId,
                UnitPrice = p.UnitPrice
            });
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }
    }
}

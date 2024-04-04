using CatalogService.Database;
using CatalogService.Database.Entities;
using CatalogService.Services.Interfaces;

namespace CatalogService.Services.Implementations
{
    public class CatagoryService : ICatagoryService
    {
        AppDbContext _context;
        public CatagoryService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCatagories()
        {
            return _context.Categories;
        }
    }
}

using CatalogService.Database.Entities;

namespace CatalogService.Services.Interfaces
{
    public interface ICatagoryService
    {
        IEnumerable<Category> GetCatagories();
    }
}

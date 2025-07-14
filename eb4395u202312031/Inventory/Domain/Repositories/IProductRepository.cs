using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Inventory.Domain.Model.Aggregates;

namespace eb4395u202312031.Inventory.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<bool> ProductExistsBySerialNumber(string serialNumber);
    
    Task<Product?> FindProductBySerialNumberAsync(string serialNumber);
    
}
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb4395u202312031.Inventory.Domain.Model.Aggregates;
using eb4395u202312031.Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace eb4395u202312031.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository (AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<bool> ProductExistsBySerialNumber(string serialNumber)
    {
        return await Context.Set<Product>().AnyAsync(product => product.SerialNumber == serialNumber);
    }
}
using eb4395u202312031.Inventory.Domain.Repositories;

namespace eb4395u202312031.Inventory.Interfaces.ACL;

public interface IProductContextFacade
{
    public Task<int>FetchProductBySerialNumberAsync(string serialNumber);
}
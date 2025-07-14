using eb4395u202312031.Inventory.Domain.Model.Queries;
using eb4395u202312031.Inventory.Domain.Services;
using eb4395u202312031.Inventory.Interfaces.ACL;

namespace eb4395u202312031.Inventory.Application.ACL;

public class ProductContextFacade(IProductQueryService productQueryService) : IProductContextFacade
{
    public async Task<int> FetchProductBySerialNumberAsync(string serialNumber)
    {
        
        var product = new GetProductBySerialNumber(serialNumber);
        var productQuery = await productQueryService.Handle(product);
        return productQuery?.Id ?? 0;
    }
}
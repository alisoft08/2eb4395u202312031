using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Inventory.Domain.Model.Aggregates;
using eb4395u202312031.Inventory.Domain.Model.Commands;
using eb4395u202312031.Inventory.Domain.Repositories;
using eb4395u202312031.Inventory.Domain.Services;

namespace eb4395u202312031.Inventory.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var productExists = await productRepository.ProductExistsBySerialNumber(command.serialNumber);

        if (productExists)
        {
            throw new Exception($"Product with serial number {command.serialNumber} already exists");
        }
        
        var product = new Product(command);
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }
}
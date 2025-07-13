using eb4395u202312031.Inventory.Domain.Model.Aggregates;
using eb4395u202312031.Inventory.Domain.Model.Commands;

namespace eb4395u202312031.Inventory.Domain.Services;

public interface IProductCommandService
{
    public Task<Product?> Handle(CreateProductCommand command);
    
}
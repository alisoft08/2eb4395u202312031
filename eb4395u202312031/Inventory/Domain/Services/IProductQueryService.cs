using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Inventory.Domain.Model.Aggregates;
using eb4395u202312031.Inventory.Domain.Model.Queries;

namespace eb4395u202312031.Inventory.Domain.Services;

public interface IProductQueryService
{
    public Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
}
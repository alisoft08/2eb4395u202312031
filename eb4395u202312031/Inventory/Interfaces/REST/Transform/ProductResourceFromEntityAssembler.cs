using eb4395u202312031.Inventory.Domain.Model.Aggregates;
using eb4395u202312031.Inventory.Interfaces.REST.Resources;
namespace eb4395u202312031.Inventory.Interfaces.REST.Transform;
public static class ProductResourceFromEntityAssembler
{
    
    
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        var statusDescription = string.Empty;
        
        if(entity.Status == 1)
        {
            statusDescription = "OPERATIONAL";
        }
        else if(entity.Status == 2)
        {
            statusDescription = "UNOPERATIONAL";
        }
        
        return new ProductResource(entity.Id, entity.Brand, entity.Model, entity.SerialNumber, statusDescription);
    }
    public static ProductResource ToResourceFromEntity(Product entity, string statusDescription)
    {
        
        return new ProductResource(entity.Id, entity.Brand, entity.Model, entity.SerialNumber, statusDescription);
    }
}
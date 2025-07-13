using eb4395u202312031.Inventory.Domain.Model.Commands;
using eb4395u202312031.Inventory.Interfaces.REST.Resources;

namespace eb4395u202312031.Inventory.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{

    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource, string statusDescription)
    {
        return new CreateProductCommand(resource.Brand, resource.Model, resource.SerialNumber, statusDescription);
    }
}
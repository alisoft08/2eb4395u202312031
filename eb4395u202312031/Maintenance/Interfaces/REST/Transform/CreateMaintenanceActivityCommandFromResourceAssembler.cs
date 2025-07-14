using eb4395u202312031.Maintenance.Domain.Model.Commands;
using eb4395u202312031.Maintenance.Interfaces.REST.Resources;

namespace eb4395u202312031.Maintenance.Interfaces.REST.Transform;

public static class CreateMaintenanceActivityCommandFromResourceAssembler
{

    public static CreateMaintenanceActivityCommand ToCommandFromResource(CreateMaintenanceActivityResource resource)
    {
        return new CreateMaintenanceActivityCommand(resource.ProductSerialNumber, resource.Summary, resource.Description, resource.ActivityResult);
    }
    
}
using eb4395u202312031.Maintenance.Domain.Model.Aggregates;
using eb4395u202312031.Maintenance.Interfaces.REST.Resources;

namespace eb4395u202312031.Maintenance.Interfaces.REST.Transform;

public static class MaintenanceActivityResourceFromEntityAssembler
{
    public static MaintenanceActivityResource ToResourceFromEntity(MaintenanceActivity entity)
    {
        return new MaintenanceActivityResource(
            entity.Id,
            entity.ProductSerialNumber,
            entity.Summary,
            entity.Description,
            entity.ActivityResult);


    }
}
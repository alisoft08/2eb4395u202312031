using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Inventory.Interfaces.ACL;
using eb4395u202312031.Maintenance.Domain.Model.Aggregates;
using eb4395u202312031.Maintenance.Domain.Model.Commands;
using eb4395u202312031.Maintenance.Domain.Repositories;
using eb4395u202312031.Maintenance.Domain.Services;

namespace eb4395u202312031.Maintenance.Application.Internal.CommandServices;

public class MaintenanceActivityCommandService(IMaintenanceActivityRepository repository, IUnitOfWork unitOfWork, IProductContextFacade facade ) : IMaintenanceActivityCommandService
{
    public async Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command)
    {
        var MaintenanceActivity = new MaintenanceActivity(command);
        var product = await facade.FetchProductBySerialNumberAsync(command.ProductSerialNumber);
        if(product == 0)
            throw new Exception($"Product with serial number {command.ProductSerialNumber} not found");
        
        try
        {
            await repository.AddAsync(MaintenanceActivity);
            await unitOfWork.CompleteAsync();
            return MaintenanceActivity;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
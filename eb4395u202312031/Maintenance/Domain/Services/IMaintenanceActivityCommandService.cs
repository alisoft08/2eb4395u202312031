using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.Maintenance.Domain.Model.Aggregates;
using eb4395u202312031.Maintenance.Domain.Model.Commands;

namespace eb4395u202312031.Maintenance.Domain.Services;

public interface IMaintenanceActivityCommandService
{
    public Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command);
}
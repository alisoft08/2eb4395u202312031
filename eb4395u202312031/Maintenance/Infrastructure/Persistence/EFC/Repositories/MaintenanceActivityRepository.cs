using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb4395u202312031.Inventory.Domain.Model.Aggregates;
using eb4395u202312031.Inventory.Domain.Repositories;
using eb4395u202312031.Maintenance.Domain.Model.Aggregates;
using eb4395u202312031.Maintenance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace eb4395u202312031.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class MaintenanceActivityRepository (AppDbContext context) : BaseRepository<MaintenanceActivity>(context), IMaintenanceActivityRepository
{
 
}
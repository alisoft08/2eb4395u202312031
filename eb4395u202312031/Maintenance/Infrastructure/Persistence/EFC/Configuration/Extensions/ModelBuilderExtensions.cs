using eb4395u202312031.Maintenance.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202312031.Maintenance.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMaintenanceActivityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<MaintenanceActivity>().HasKey(c => c.Id);
        builder.Entity<MaintenanceActivity>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
    }
}
using eb4395u202312031.Inventory.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202312031.Inventory.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProductConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Product>().HasKey(c => c.Id);
        builder.Entity<Product>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
    }
}
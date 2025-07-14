namespace eb4395u202312031.Maintenance.Interfaces.REST.Resources;

public record CreateMaintenanceActivityResource(string ProductSerialNumber, string Summary, string Description, int ActivityResult);
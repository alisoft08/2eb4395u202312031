namespace eb4395u202312031.Maintenance.Interfaces.REST.Resources;

public record MaintenanceActivityResource(int id, string ProductSerialNumber, string Summary, string Description, int ActivityResult);
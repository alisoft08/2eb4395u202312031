namespace eb4395u202312031.Maintenance.Domain.Model.Commands;

public record CreateMaintenanceActivityCommand(string ProductSerialNumber, string Summary, string Description, int ActivityResult);
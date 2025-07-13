namespace eb4395u202312031.Inventory.Domain.Model.Commands;

public record CreateProductCommand(string brand, string model, string serialNumber, string statusDescription);

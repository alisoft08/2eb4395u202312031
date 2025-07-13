using System.ComponentModel.DataAnnotations.Schema;
using eb4395u202312031.Inventory.Domain.Model.Commands;

namespace eb4395u202312031.Inventory.Domain.Model.Aggregates;

public class Product
{
    public int Id { get; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public int Status { get; set; }
    
    // [NotMapped]
    // public string StatusDescription {get; set;}
    
    [NotMapped]
    public string StatusDescription => Status switch
    {
        1 => "OPERATIONAL",
        2 => "UNOPERATIONAL",
        _ => "UNKNOWN"
    };


    public Product(string brand, string model, string serialNumber, string statusDescription)
    {
        Brand = brand;
        Model = model;
        SerialNumber = serialNumber;
        StatusDescription = statusDescription;
        
        if (StatusDescription == "OPERATIONAL")
        {
            Status = 1;
        }
        else if (StatusDescription == "UNOPERATIONAL")
        {
            Status = 2;
        }
        
        
    }

    public Product(CreateProductCommand command)
    {
        Brand =command.brand;
        Model = command.model;
        SerialNumber = command.serialNumber;
        StatusDescription = command.statusDescription;
        if (command.statusDescription != "OPERATIONAL" && command.statusDescription != "UNOPERATIONAL")
        {
            throw new ArgumentOutOfRangeException($"Invalid status description {command.statusDescription}, expected 'OPERATIONAL' or 'UNOPERATIONAL'.");
        }
        if (StatusDescription == "OPERATIONAL")
        {
            Status = 1;
        }
        else if (StatusDescription == "UNOPERATIONAL")
        {
            Status = 2;
        }
    }
}
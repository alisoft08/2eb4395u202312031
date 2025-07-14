using eb4395u202312031.Maintenance.Domain.Model.Commands;

namespace eb4395u202312031.Maintenance.Domain.Model.Aggregates;

public class MaintenanceActivity
{
    public int Id { get; }
    public string ProductSerialNumber { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int ActivityResult { get; set; }
    
    public MaintenanceActivity(){}

    public MaintenanceActivity(string productSerialNumber, string summary, string description, int activityResult)
    {
        ProductSerialNumber = productSerialNumber;
        Summary = summary;
        Description = description;
        if (activityResult < 0 || activityResult > 1)
        {
            throw new ArgumentOutOfRangeException($"Invalid activity result {activityResult}, expected 0 or 1");
        }
        ActivityResult = activityResult;
    }

    public MaintenanceActivity(CreateMaintenanceActivityCommand command)
    {
        ProductSerialNumber = command.ProductSerialNumber;
        Summary = command.Summary;
        Description = command.Description;
        if (command.ActivityResult < 0 || command.ActivityResult > 1)
        {
            throw new ArgumentOutOfRangeException($"Invalid activity result {command.ActivityResult}, expected 0 or 1");
        }
        ActivityResult = command.ActivityResult;
    }
    
}
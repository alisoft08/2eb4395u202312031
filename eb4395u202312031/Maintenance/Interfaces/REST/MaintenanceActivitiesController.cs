using System.Net.Mime;
using eb4395u202312031.Maintenance.Domain.Services;
using eb4395u202312031.Maintenance.Interfaces.REST.Resources;
using eb4395u202312031.Maintenance.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eb4395u202312031.Maintenance.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Maintenance Activity Endpoints.")]
public class MaintenanceActivitiesController (IMaintenanceActivityCommandService maintenanceActivityCommandService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create Maintenance Activity", "Create a new Maintenance Activity.", OperationId = "CreateMaintenanceActivity")]
    [SwaggerResponse(201, "The Maintenance Activity was created.", typeof(MaintenanceActivityResource))]
    [SwaggerResponse(400, "The Maintenance Activity was not created.")]
    public async Task<IActionResult> CreateProfile(CreateMaintenanceActivityResource resource)
    {
        var createMaintenanceActivityCommand = CreateMaintenanceActivityCommandFromResourceAssembler.ToCommandFromResource(resource);
        var MaintenanceActivity = await maintenanceActivityCommandService.Handle(createMaintenanceActivityCommand);
        if (MaintenanceActivity is null) return BadRequest();
        var MaintenanceActivityResource = MaintenanceActivityResourceFromEntityAssembler.ToResourceFromEntity(MaintenanceActivity);
        return StatusCode(201, MaintenanceActivityResource);    
    }
}
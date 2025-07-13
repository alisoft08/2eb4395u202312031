using System.Net.Mime;
using eb4395u202312031.Inventory.Domain.Model.Queries;
using eb4395u202312031.Inventory.Domain.Services;
using eb4395u202312031.Inventory.Interfaces.REST.Resources;
using eb4395u202312031.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eb4395u202312031.Inventory.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Product Endpoints")]
public class ProductsController(IProductCommandService productCommandService, IProductQueryService productQueryService)
    : ControllerBase
{

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new product",
        Description = "Creates a new product with the provided details.",
        OperationId = "CreateProduct")]
    [SwaggerResponse(StatusCodes.Status201Created, "Product created successfully", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid product data")]
    public async Task<IActionResult> CreateProduct([FromQuery] string statusDescription, [FromBody] CreateProductResource resource)
    {
        if (string.IsNullOrWhiteSpace(statusDescription))
            return BadRequest(new { error = "statusDescription query parameter is required" });

        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource, statusDescription);
        var product = await productCommandService.Handle(createProductCommand);
    
        if (product is null) return BadRequest("Product could not be created.");

        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product, statusDescription);
        
        return StatusCode(201, productResource );  
    }

    [HttpGet] 
    [SwaggerOperation( 
        Summary = "Gets all products",
        Description = "Retrieves a list of all available products.",
        OperationId = "GetAllProducts")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of products retrieved successfully", typeof(IEnumerable<ProductResource>))]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await productQueryService.Handle(new GetAllProductsQuery());
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return StatusCode(201, resources ); 
    }
    
    
}
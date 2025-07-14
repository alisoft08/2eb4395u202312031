using eb4395u202312031.API.Shared.Domain.Repositories;
using eb4395u202312031.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4395u202312031.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb4395u202312031.Inventory.Application.ACL;
using eb4395u202312031.Inventory.Application.Internal.CommandServices;
using eb4395u202312031.Inventory.Application.Internal.QueryServices;
using eb4395u202312031.Inventory.Domain.Repositories;
using eb4395u202312031.Inventory.Domain.Services;
using eb4395u202312031.Inventory.Infrastructure.Persistence.EFC.Repositories;
using eb4395u202312031.Inventory.Interfaces.ACL;
using eb4395u202312031.Maintenance.Application.Internal.CommandServices;
using eb4395u202312031.Maintenance.Domain.Repositories;
using eb4395u202312031.Maintenance.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "ISAConnect.API",
            Version = "v1",
            Description = "ISA Connect Platform API",
            TermsOfService = new Uri("https://www.isaitaly.com/"),
            Contact = new OpenApiContact
            {
                Name = "u202312031 - Alison Arrieta",
                Email = "u202312031@upc.edu.pe"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IProductContextFacade, ProductContextFacade>();

builder.Services.AddScoped<IMaintenanceActivityRepository, MaintenanceActivityRepository>();
builder.Services.AddScoped<IMaintenanceActivityCommandService, MaintenanceActivityCommandService>();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");
// Add Authorization Middleware to Pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
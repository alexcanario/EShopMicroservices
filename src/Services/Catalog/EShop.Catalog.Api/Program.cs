using EShop.Catalog.Api.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

var asembly = typeof(Program).Assembly;
var sqlCatalogConnectionString = builder.Configuration.GetConnectionString("CatalogConnection")!;

builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssemblies(asembly);
	config.AddOpenBehavior(typeof(ValidationBehavior<,>));
	config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(asembly);

builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
	options.Connection(sqlCatalogConnectionString);
})
	.UseLightweightSessions();

if (builder.Environment.IsDevelopment())
{
	builder.Services.InitializeMartenWith<CatalogSeed>();
}


builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
	.AddNpgSql(sqlCatalogConnectionString);

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health", new HealthCheckOptions 
{ 
	ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse 
});

#endregion

app.Run();
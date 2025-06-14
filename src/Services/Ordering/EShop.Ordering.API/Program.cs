using EShop.Ordering.API;
using EShop.Ordering.App;
using EShop.Ordering.Infra;
using EShop.Ordering.Infra.Database.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

builder.Services
	.AddApplicationServices()
	.AddInfraServices(builder.Configuration)
	.AddApiServices();
#endregion

var app = builder.Build();

#region Configure services in container

app.UseApiServices();

#endregion

if (app.Environment.IsDevelopment())
{
	await app.InitializeDatabaseAsync();
}

app.Run();
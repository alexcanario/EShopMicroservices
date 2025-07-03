var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

builder.Services
	.AddApplicationServices(builder.Configuration)
	.AddInfraServices(builder.Configuration)
	.AddApiServices(builder.Configuration);
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
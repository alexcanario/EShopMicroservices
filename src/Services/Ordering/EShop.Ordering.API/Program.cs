using EShop.Ordering.API;
using EShop.Ordering.App;
using EShop.Ordering.Infra;
using EShop.Ordering.Infra.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services
	.AddApiServices()
	.AddApplicationServices()
	.AddInfraServices(builder.Configuration);
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
app.UseApiServices();

#endregion

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
using EShop.BuildingBlocks.Behaviors;
using EShop.BuildingBlocks.Exceptions.Handler;

using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;

using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

var basketConnectionString = builder.Configuration.GetConnectionString("BasketConnection");

#region Add services to the container.

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssemblies(assembly);
	config.AddOpenBehavior(typeof(ValidationBehavior<,>));
	config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(options =>
{
	options.Connection(basketConnectionString!);
	options.AutoCreateSchemaObjects = AutoCreate.All;
	options.Schema.For<ShoppingCart>().Identity(x => x.Username);
})
	.UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
	//options.InstanceName = "Basket_";
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks()
	.AddNpgSql(builder.Configuration.GetConnectionString("BasketConnection")!)
	.AddRedis(builder.Configuration.GetConnectionString("RedisConnection")!);

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.MapCarter();
app.UseExceptionHandler(options => { });
app.MapHealthChecks("/health", new HealthCheckOptions 
{ 
	ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse 
});

#endregion

app.Run();

using EShop.BuildingBlocks.Behaviors;
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

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.MapCarter();

#endregion

app.Run();

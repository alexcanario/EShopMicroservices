using EShop.BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

#region Add services to the container.

builder.Services.AddCarter();

builder.Services.AddMediatR(config => 
{ 
	config.RegisterServicesFromAssemblies(assembly);
	config.AddOpenBehavior(typeof(ValidationBehavior<,>));
	config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.MapCarter();

#endregion

app.Run();

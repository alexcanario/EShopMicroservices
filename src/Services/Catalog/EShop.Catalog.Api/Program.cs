using EShop.Catalog.Api.Data;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

var asembly = typeof(Program).Assembly;
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
	options.Connection(builder.Configuration.GetConnectionString("CatalogConnection")!);
})
	.UseLightweightSessions();

if(builder.Environment.IsDevelopment())
{
	builder.Services.InitializeMartenWith<CatalogSeed>();
}


builder.Services.AddExceptionHandler<CustomExceptionHandler>();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.MapCarter();

app.UseExceptionHandler(options => { });

#endregion

app.Run();
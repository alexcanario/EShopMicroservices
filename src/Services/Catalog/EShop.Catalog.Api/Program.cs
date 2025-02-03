var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCarter();   

builder.Services.AddMediatR(config => 
{ 
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CatalogConnection")!);
})
    .UseLightweightSessions();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapCarter();

app.Run();
using EShop.BuildingBlocks.Behavior;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

var asembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssemblies(asembly);
	config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(asembly);

builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
	options.Connection(builder.Configuration.GetConnectionString("CatalogConnection")!);
})
	.UseLightweightSessions();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.MapCarter();

app.UseExceptionHandler(exceptionHandlerApp =>
{
	exceptionHandlerApp.Run(async context =>
	{
		var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
		if (exception is null) return;

		var problemDetails = new ProblemDetails
		{
			Title = exception.Message,
			Status = StatusCodes.Status500InternalServerError,
			Detail = exception.StackTrace,
		};

		var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
		logger.LogError(exception, exception.Message);

		context.Response.StatusCode = StatusCodes.Status500InternalServerError;
		context.Response.ContentType = "application/problem+json";

		await context.Response.WriteAsJsonAsync(problemDetails);
	});
});

#endregion

app.Run();
using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EShop.BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> Logger)
	: IPipelineBehavior<TRequest, TResponse>
		where TRequest : notnull, IRequest<TResponse>
		where TResponse : notnull
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		Logger.LogInformation("[START] Handling REQUEST = {Request} - RESPONSE={Response} RequestData={RequestData}", 
			typeof(TRequest).Name, typeof(TResponse).Name, request);

		var timer = new Stopwatch();
		timer.Start();

		var response = await next();

		timer.Stop();
		var timeTaken = timer.Elapsed;
		
		if(timeTaken > TimeSpan.FromSeconds(3)) 
		{
			Logger.LogWarning("[SLOW] [PERFORMANCE] Handling REQUEST = {Request} - RESPONSE={Response} RequestData={RequestData} took {TimeTaken} seconds",
				typeof(TRequest).Name, typeof(TResponse).Name, request, timeTaken);
		}
		else
		{
			Logger.LogInformation("[END] Handling REQUEST = {Request} - RESPONSE={Response} RequestData={RequestData} took {TimeTaken} seconds",
				typeof(TRequest).Name, typeof(TResponse).Name, request, timeTaken);
		}

		return response;
	}
}
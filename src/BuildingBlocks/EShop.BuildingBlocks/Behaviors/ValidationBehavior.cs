using EShop.BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace EShop.BuildingBlocks.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> Validators) 
	: IPipelineBehavior<TRequest, TResponse> 
	where TRequest : ICommand<TResponse>
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		var context = new ValidationContext<TRequest>(request);

		var validationResult = await Task.WhenAll(Validators.Select(v => v.ValidateAsync(context, cancellationToken)));

		var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();

		if (failures.Count > 0) throw new ValidationException(failures);

		return await next();
	}
}
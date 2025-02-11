namespace EShop.Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string Username) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsDeleted);

public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
{
	public DeleteBasketValidator()
	{
		RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
	}
}

public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
	public Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
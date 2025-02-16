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

public class DeleteBasketCommandHandler(IBasketRepository BasketRepository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
	public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
	{
		//TODO: Delete the basket from the database
		var isDeleted = await BasketRepository.DeleteBasketAsync(command.Username, cancellationToken);

		return new DeleteBasketResult(isDeleted);
	}
}
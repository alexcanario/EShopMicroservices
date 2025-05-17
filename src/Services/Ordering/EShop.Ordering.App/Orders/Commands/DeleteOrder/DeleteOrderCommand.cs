namespace EShop.Ordering.App.Orders.Commands.DeleteOrder;

public sealed record DeleteOrderResponse(bool IsDeleted);

public sealed record DeleteOrderCommand(Guid Id) : ICommand<DeleteOrderResponse>;

public sealed class DeleteOrderCommandValidate : AbstractValidator<DeleteOrderCommand>
{
	public DeleteOrderCommandValidate()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage("Id is required");
	}
}
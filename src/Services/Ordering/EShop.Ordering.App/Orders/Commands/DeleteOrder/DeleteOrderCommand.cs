namespace EShop.Ordering.App.Orders.Commands.DeleteOrder;

public record DeleteOrderResponse(bool IsDeleted);

public record DeleteOrderCommand(Guid Id) : ICommand<DeleteOrderResponse>;

public class DeleteOrderCommandValidate : AbstractValidator<DeleteOrderCommand>
{
	public DeleteOrderCommandValidate()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage("Id is required");
	}
}
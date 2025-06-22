using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

public sealed record CreateOrderResult(Guid OrderId);

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
	public CreateOrderCommandValidator()
	{
		RuleFor(c => c.Order.OrderName).NotEmpty().WithMessage("Name is required");
		RuleFor(c => c.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
		RuleFor(c => c.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
	}
}
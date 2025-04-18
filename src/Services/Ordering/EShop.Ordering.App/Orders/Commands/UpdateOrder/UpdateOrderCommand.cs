using System.Data.SqlTypes;

namespace EShop.Ordering.App.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool Successfully = false);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
	public UpdateOrderCommandValidator()
	{
		RuleFor(u => u.Order.Id).NotEmpty().WithMessage("Id is required");
		RuleFor(u => u.Order.OrderName).NotNull().WithMessage("Name is required");
		RuleFor(u => u.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
	}
}
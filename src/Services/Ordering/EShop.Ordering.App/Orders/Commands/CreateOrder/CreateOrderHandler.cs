namespace EShop.Ordering.App.Orders.Commands.CreateOrder;

public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
	public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
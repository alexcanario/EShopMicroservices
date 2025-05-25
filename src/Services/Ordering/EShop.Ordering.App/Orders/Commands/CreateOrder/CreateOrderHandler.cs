namespace EShop.Ordering.App.Orders.Commands.CreateOrder;

internal sealed class CreateOrderHandler(IOrderingDbContext context) 
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
	public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
	{
		//create order entity from command object
		//save to database
		//return order id

		var order = CreateNewOrder(command.Order);
		await context.Orders.AddAsync(order, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);

		return new CreateOrderResult(order.Id.Value);
	}

	private static Order CreateNewOrder(OrderDto orderDto)
	{
		var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName,
			orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine,
			orderDto.ShippingAddress.Country, orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);

		var billingAddress = Address.Of(orderDto.BillingAddress.FirstName, orderDto.BillingAddress.LastName,
			orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine, orderDto.BillingAddress.Country,
			orderDto.BillingAddress.State, orderDto.BillingAddress.ZipCode);

		var order = Order.Create(
			id: OrderId.Of(Guid.NewGuid()),
			customerId: CustomerId.Of(orderDto.CustomerId),
			orderName: OrderName.Of(orderDto.OrderName),
			shippingAddress: shippingAddress,
			billingAddress: billingAddress,
			payment: Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.ExpirationDate, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod)
		);

		foreach (var item in orderDto.OrderItems)
		{
			order.AddItem(ProductId.Of(item.ProductId), item.Quantity, item.Price);
		}

		return order;
	}
}
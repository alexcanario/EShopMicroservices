using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Orders.Commands.UpdateOrder;

internal sealed class UpdateOrderHandler(IOrderingDbContext ctx) 
    : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
	public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
	{
		//Find order by id
		//Update order entity from command object
		//save to database
		//return successfully or not

		var orderId = OrderId.Of(command.Order.Id);
		
		var orderToUpdate = await ctx.Orders.FindAsync([orderId], cancellationToken);
		if (orderToUpdate is null)
			throw new OrderNotFoundException(command.Order.Id);

		UpdateOrderWithNewValues(orderToUpdate, command.Order);

		ctx.Orders.Update(orderToUpdate);
		await ctx.SaveChangesAsync(cancellationToken);

		return new UpdateOrderResult(true);
	}

	private static void UpdateOrderWithNewValues(Order order, OrderDto orderDto)
	{
		var updatedOrderName = OrderName.Of(orderDto.OrderName);
		var updatedShippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName,
			orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine,
			orderDto.ShippingAddress.Country, orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);

		var updatedBillingAddress = Address.Of(orderDto.BillingAddress.FirstName, orderDto.BillingAddress.LastName, orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine, orderDto.BillingAddress.Country, orderDto.BillingAddress.State, orderDto.BillingAddress.ZipCode);

		var updatedPayment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.ExpirationDate, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod);

		order.Update(
			orderName: updatedOrderName,
			shippingAddress: updatedShippingAddress,
			billingAddress: updatedBillingAddress,
			payment: updatedPayment,
			status: orderDto.Status
		);
	}
}
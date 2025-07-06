namespace EShop.Ordering.App.Extensions;

public static class BasketCheckoutEventHandlerExtensions
{
	public static CreateOrderCommand ToCreateOrderCommand(this BasketCheckoutEvent message)
	{
		var addressDto = new AddressDto(
			message.FirstName,
			message.LastName,
			message.EmailAddress,
			message.AddressLine,
			message.Country,
			message.State,
			message.ZipCode);

		var paymentDto = new PaymentDto(
			message.CardName,
			message.CardNumber,
			message.CardExpiration,
			message.CardSecurityNumber,
			message.PaymentMethod);

		var orderId = Guid.NewGuid();

		return new CreateOrderCommand(new OrderDto(
			Id: orderId,
			CustomerId: message.CustomerId,
			OrderName: message.UserName,
			ShippingAddress: addressDto,
			BillingAddress: addressDto,
			Payment: paymentDto,
			Status: OrderStatus.Pending,
			OrderItems: message.Items.Select(item => new OrderItemDto
			(
				orderId,
				item.ProductId,
				item.Quantity,
				item.Price
			)).ToList()));
	}
}
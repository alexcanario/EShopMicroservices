using EShop.Ordering.Domain.Enums;

namespace EShop.Ordering.App.DataTransfers;

public record OrderDto(
	Guid Id, 
	Guid CustomerId, 
	string OrderName, 
	AddressDto ShippingAddress, 
	AddressDto BillingAddress, 
	PaymentDto Payment, 
	OrderStatus Status, 
	IList<OrderItemDto> OrderItems);
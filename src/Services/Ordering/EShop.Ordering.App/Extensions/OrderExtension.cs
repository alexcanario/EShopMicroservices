using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Extensions;

public static class OrderExtension
{
    public static OrderDto ToOrderDto(this Order order)
    {
        return new OrderDto(
            order.Id.Value,
            order.CustomerId.Value,
            order.OrderName.Value,
            order.ShippingAddress.ToDto(),
            order.BillingAddress.ToDto(),
            order.Payment.ToDto(),
            order.Status,
            order.OrderItems.ToDtoList());
    }

    public static IList<OrderDto> ToDtoList(this IList<Order> orders)
    {
        return orders.Select(order => order.ToOrderDto()).ToList();
    }
}
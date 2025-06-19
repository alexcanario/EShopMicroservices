using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Extensions;

public static class OrderItemsExtensions
{
    public static OrderItemDto ToDto(this OrderItem item)
    {
        return new OrderItemDto(
            item.OrderId.Value,
            item.ProductId.Value,
            item.Quantity,
            item.UnitPrice);
    }

    public static IList<OrderItemDto> ToDtoList(this IReadOnlyCollection<OrderItem> items)
    {
        return items.Select(item => item.ToDto()).ToList();
    }
}
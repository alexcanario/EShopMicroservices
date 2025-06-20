using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Orders.Queries.GetOrdersByName;

public sealed record GetOrdersByNameQueryResult(IEnumerable<OrderDto> Orders);
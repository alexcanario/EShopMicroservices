using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Orders.Queries.GetOrdersByCustomer;

public sealed record GetOrdersByCustomerQueryResult(IList<OrderDto> Orders);
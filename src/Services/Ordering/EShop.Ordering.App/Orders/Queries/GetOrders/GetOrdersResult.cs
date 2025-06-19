using EShop.BuildingBlocks.Pagination;
using EShop.Ordering.App.DataTransfers;

namespace EShop.Ordering.App.Orders.Queries.GetOrders;

public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
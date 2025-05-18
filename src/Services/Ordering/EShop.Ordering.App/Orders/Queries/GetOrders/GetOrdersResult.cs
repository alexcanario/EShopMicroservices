using EShop.BuildingBlocks.Pagination;

namespace EShop.Ordering.App.Orders.Queries.GetOrders;

public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
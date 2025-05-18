using EShop.BuildingBlocks.Pagination;

namespace EShop.Ordering.App.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest) : IQuery<GetOrdersResult>;
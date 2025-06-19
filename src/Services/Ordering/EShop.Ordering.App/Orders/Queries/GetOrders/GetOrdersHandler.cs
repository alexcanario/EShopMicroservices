using Microsoft.EntityFrameworkCore;

namespace EShop.Ordering.App.Orders.Queries.GetOrders;

internal class GetOrdersHandler (IOrderingDbContext context)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageSize = query.PaginationRequest.PageSize;
        var pageIndex = query.PaginationRequest.PageIndex;
        var totalCount = await context.Orders.LongCountAsync(cancellationToken);

        var orders = await context.Orders
            .Include(o => o.OrderItems)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetOrdersResult(new PaginatedResult<OrderDto>(pageIndex, pageSize, totalCount, orders.ToDtoList()));
    }
}
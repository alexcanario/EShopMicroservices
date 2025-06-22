using Microsoft.EntityFrameworkCore;

namespace EShop.Ordering.App.Orders.Queries.GetOrdersByName;

internal sealed class GetOrdersByNameQueryHandler(IOrderingDbContext context)
    : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameQueryResult>
{
    public async Task<GetOrdersByNameQueryResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        //Get orders by name using dbContext
        //return result

        var orders = await context.Orders
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .Where(o => o.OrderName.Value.Contains(query.Name))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);

        return new GetOrdersByNameQueryResult(orders.ToDtoList());
    }
}
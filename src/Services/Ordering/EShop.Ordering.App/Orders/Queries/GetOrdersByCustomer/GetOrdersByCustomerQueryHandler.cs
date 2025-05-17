using EShop.Ordering.App.Extensions;

using Microsoft.EntityFrameworkCore;

namespace EShop.Ordering.App.Orders.Queries.GetOrdersByCustomer;

internal sealed class GetOrdersByCustomerQueryHandler(IOrderingDbContext context)
    : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerQueryResult>
{
    public async Task<GetOrdersByCustomerQueryResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders = await context.Orders
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName.Value)
            .Select(order => order.ToDto()).ToListAsync(cancellationToken);

        return new GetOrdersByCustomerQueryResult(orders);
    }
}
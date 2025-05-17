namespace EShop.Ordering.App.Orders.Queries.GetOrdersByName;

public sealed record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameQueryResult>;
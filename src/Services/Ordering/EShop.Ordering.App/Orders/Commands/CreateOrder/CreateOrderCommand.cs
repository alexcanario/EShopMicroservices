namespace EShop.Ordering.App.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;
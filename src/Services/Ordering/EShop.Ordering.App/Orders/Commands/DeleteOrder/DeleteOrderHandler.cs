namespace EShop.Ordering.App.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler(IOrderingDbContext ctx) : ICommandHandler<DeleteOrderCommand, DeleteOrderResponse>
{
	public async Task<DeleteOrderResponse> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
	{
		var orderId = OrderId.Of(command.Id);
		var orderToRemove = await ctx.Orders.FindAsync([orderId], cancellationToken);
		if (orderToRemove is null)
			throw new NotFoundException($"Order with id {orderId} not found");
		
		ctx.Orders.Remove(orderToRemove);
		await ctx.SaveChangesAsync(cancellationToken);
		
		return new DeleteOrderResponse(true);
	}
}
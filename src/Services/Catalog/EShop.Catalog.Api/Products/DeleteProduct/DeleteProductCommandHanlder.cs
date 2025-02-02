namespace EShop.Catalog.Api.Products.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;
public sealed record DeleteProductResult(bool IsSuccess);

internal class DeleteProductCommandHanlder(IDocumentSession Session, ILogger<DeleteProductCommandHanlder> Logger) 
	: ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
	public async Task<DeleteProductResult> Handle(DeleteProductCommand Command, CancellationToken cancellationToken)
	{
		Logger.LogInformation("Deleting product at DeleteProductCommandHanlder.Handle with id {ProductId}", Command.ProductId);
		Session.Delete<Product>(Command.ProductId);
		await Session.SaveChangesAsync(cancellationToken);
		return new (true);
	}
}
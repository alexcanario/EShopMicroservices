namespace EShop.Catalog.Api.Products.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, string imageFile, IList<string> Category) 
	: ICommand<UpdateProductResult>;
public sealed record UpdateProductResult(bool IsSuccess);

internal class UpdateProductCommandHandler(IDocumentSession Session, ILogger<UpdateProductCommandHandler> Logger) 
	: ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
	public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
	{
		Logger.LogInformation("UpdateProductHandler.Handle called with {@Command}", command);
		var product = await Session.LoadAsync<Product>(command.Id, cancellationToken);

		if(product is null)
		{
			Logger.LogWarning("Product with id {Id} was not found", command.Id);
			throw new ProductNotFoundException();
		}

		product.Name = command.Name;
		product.Description = command.Description;
		product.Price = command.Price;
		product.ImageFile = command.imageFile;
		product.Category = command.Category;

		Session.Update(product);
		await Session.SaveChangesAsync(cancellationToken);
		return new(true);
	}
}
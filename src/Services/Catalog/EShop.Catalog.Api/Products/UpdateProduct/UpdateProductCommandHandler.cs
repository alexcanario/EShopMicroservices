namespace EShop.Catalog.Api.Products.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, string ImageFile, IList<string> Category) 
	: ICommand<UpdateProductResult>;
public sealed record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
	public UpdateProductCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
		RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
		RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
		RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
		RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image is required.");
		RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price  must be greater than zero");
	}
}

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
		product.ImageFile = command.ImageFile;
		product.Category = command.Category;

		Session.Update(product);
		await Session.SaveChangesAsync(cancellationToken);
		return new(true);
	}
}
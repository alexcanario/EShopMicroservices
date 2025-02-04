namespace EShop.Catalog.Api.Products.CreateProduct;

public sealed record CreateProductCommand(string Name, IList<string> Category, string Description, string ImageFile, decimal Price)
	: ICommand<CreateProductResult>;

public sealed record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
		RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
		RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
		RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image is required.");
		RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price  must be greater than zero");
	}
}

internal sealed class CreateProductCommandHandler(IDocumentSession Session)
	: ICommandHandler<CreateProductCommand, CreateProductResult>
{
	public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		//Business Logic to Product Creation
		//Save product entity to database
		//Return CreateProductResult with product id

		var product = command.Adapt<Product>();
		Session.Store(product);
		await Session.SaveChangesAsync(cancellationToken);

		return new(product.Id);
	}
}
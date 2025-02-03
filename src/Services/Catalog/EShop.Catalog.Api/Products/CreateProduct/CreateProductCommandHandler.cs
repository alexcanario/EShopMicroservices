namespace EShop.Catalog.Api.Products.CreateProduct;

public sealed record CreateProductCommand(string Name, IList<string> Category, string Description, string ImageFile, decimal Price)
	: ICommand<CreateProductResult>;

public sealed record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Name field is required.");
		RuleFor(x => x.Category).NotEmpty().WithMessage("Category field is required.");
		RuleFor(x => x.Description).NotEmpty().WithMessage("Description field is required.");
		RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image file field is required.");
		RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price field must be greater than zero");
	}
}

internal sealed class CreateProductCommandHandler(IDocumentSession Session, IValidator<CreateProductCommand> Validator)
	: ICommandHandler<CreateProductCommand, CreateProductResult>
{
	public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		//Create Product Validation
		var validation = await Validator.ValidateAsync(command, cancellationToken);
		
		if (validation.IsValid is false)
		{
			var error = validation.Errors.Select(x => x.ErrorMessage).ToList();
			throw new ValidationException(error.Count > 0 
				? validation.Errors.FirstOrDefault()?.ErrorMessage 
				: "Error on CreateProductCommandHanlder validation.");
		}

		//Business Logic to Product Creation
		var product = command.Adapt<Product>();

		//Save product entity to database
		Session.Store(product);
		await Session.SaveChangesAsync(cancellationToken);

		//Return CreateProductResult with product id
		return new(product.Id);
	}
}
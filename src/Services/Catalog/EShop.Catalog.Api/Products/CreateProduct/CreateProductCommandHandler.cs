

namespace EShop.Catalog.Api.Products.CreateProduct;

internal sealed class CreateProductCommandHandler(IDocumentSession Session)
	: ICommandHandler<CreateProductCommand, CreateProductResult>
{
	public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		//Business Logic to Product Creation
		var product = request.Adapt<Product>();

		//Save product entity to database
		Session.Store(product);
		await Session.SaveChangesAsync(cancellationToken);

		//Return CreateProductResult with product id
		return new(product.Id);
	}
}
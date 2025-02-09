namespace EShop.Catalog.Api.Products.GetProductById;

public sealed record GetProductByIdResult(Product Product);
public sealed record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public class GetProductByIdQueryHandler(IDocumentSession Session) 
	: IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
{
	public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
	{
		var product = await Session.LoadAsync<Product>(query.Id, cancellationToken);

		return product is null 
			? throw new ProductNotFoundException(query.Id) 
			: new GetProductByIdResult(product);
	}
}
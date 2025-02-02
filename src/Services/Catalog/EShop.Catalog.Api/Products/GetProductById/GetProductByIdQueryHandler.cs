namespace EShop.Catalog.Api.Products.GetProductById;

public sealed record GetProductByIdResult(Product Product);
public sealed record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public class GetProductByIdQueryHandler(IDocumentSession Session, ILogger<GetProductByIdQueryHandler> Logger) 
	: IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
{
	public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
	{
		Logger.LogInformation("Querying product at GetProductByIdHandler.Handle called with {@Query}", query);

		var product = await Session.LoadAsync<Product>(query.Id, cancellationToken);

		return product is null 
			? throw new ProductNotFoundException() 
			: new GetProductByIdResult(product);
	}
}
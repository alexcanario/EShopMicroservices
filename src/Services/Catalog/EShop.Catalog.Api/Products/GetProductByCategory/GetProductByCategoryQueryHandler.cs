namespace EShop.Catalog.Api.Products.GetProductByCategory;

public sealed record GetProductByCategoryResult(IEnumerable<Product> Products);
public sealed record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

internal class GetProductByCategoryQueryHandler(IDocumentSession Session, ILogger<GetProductByCategoryQueryHandler> Logger) 
	: IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
	public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
	{
		Logger.LogInformation("Querying product at GetProductByCategoryHandler.Handle called with {@Query}", query);

		var products = await Session.Query<Product>()
			.Where(p => p.Category.Contains(query.Category))
			.ToListAsync(cancellationToken);

		return products.Any()
			? new GetProductByCategoryResult(products)
			: throw new ProductNotFoundException(default);
	}
}
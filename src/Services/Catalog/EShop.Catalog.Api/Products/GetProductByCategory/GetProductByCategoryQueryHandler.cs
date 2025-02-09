namespace EShop.Catalog.Api.Products.GetProductByCategory;

public sealed record GetProductByCategoryResult(IEnumerable<Product> Products);
public sealed record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

internal class GetProductByCategoryQueryHandler(IDocumentSession Session) 
	: IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
	public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
	{
		var products = await Session.Query<Product>()
			.Where(p => p.Category.Contains(query.Category))
			.ToListAsync(cancellationToken);

		return products.Any()
			? new GetProductByCategoryResult(products)
			: throw new ProductNotFoundException(default);
	}
}
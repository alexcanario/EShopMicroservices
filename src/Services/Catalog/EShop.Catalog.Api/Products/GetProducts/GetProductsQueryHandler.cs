namespace EShop.Catalog.Api.Products.GetProducts;

internal sealed record GetProductsQuery(int? PageNumber = 1, int? PageSize = 5) : IQuery<GetProductsResult>;
internal sealed record GetProductsResult(IEnumerable<Product> Products);

internal sealed class GetProductsQueryHandler(IDocumentSession Session)
	: IQueryHandler<GetProductsQuery, GetProductsResult>
{
	public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		// Se PageNumber ou PageSize não forem fornecidos, retorna todos os produtos
		IEnumerable<Product> products;
		
		if (query is { PageNumber: not null, PageSize: not null })
		{
			products = await Session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
		}
		else
		{
			products = await Session.Query<Product>().ToListAsync(cancellationToken);
		}

		return new GetProductsResult(products);
	}
}
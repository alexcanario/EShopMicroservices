using Marten.Pagination;

namespace EShop.Catalog.Api.Products.GetProducts;

internal sealed record GetProductsQuery(int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsResult>;
internal sealed record GetProductsResult(IEnumerable<Product> Products);

internal sealed class GetProductsHandler(IDocumentSession Session, ILogger<GetProductsHandler> Logger)
	: IQueryHandler<GetProductsQuery, GetProductsResult>
{
	public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		Logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

		var products = await Session.Query<Product>().ToPagedListAsync(query.PageNumber, query.PageSize, cancellationToken);

		return new(products);
	}
}
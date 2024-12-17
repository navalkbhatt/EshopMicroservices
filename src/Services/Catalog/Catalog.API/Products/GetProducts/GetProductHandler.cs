
namespace Catalog.API.Products.GetProducts
{
    internal record GetProductsQuery: IQuery<GetProductResult>;
    internal record GetProductResult(IEnumerable<Product> Products);

    public class GetProductHandler(IDocumentSession documentSession,ILogger<GetProductHandler> logger) : IQueryHandler<GetProductsQuery, GetProductResult>
    {
        async Task<GetProductResult> IRequestHandler<GetProductsQuery, GetProductResult>.Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductHandler.Handle Called with {@Query}", query);
            var products = await documentSession.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductResult(products);

        }
    }
}

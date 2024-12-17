
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string category): IQuery<GetPrductByCategoryResult>;
    public record GetPrductByCategoryResult(IEnumerable<Product> Products) { }


    public class GetProductByCategoryHandler(
        ILogger<GetProductByCategoryHandler>logger, 
        IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetPrductByCategoryResult>
    {
        public async Task<GetPrductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByCategoryHandler.Handle Called with {@query}", query);
            var products = await session.Query<Product>().Where(category => category.Category.Contains(query.category)).ToListAsync();
            return new GetPrductByCategoryResult(products);
        }
    }
}

using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Abstractions.Shared;
using static MonolithicBase.Contract.Services.V2.Product.Response;

namespace MonolithicBase.Contract.Services.V2.Product;

public static class Query
{
    public record GetProductsQuery() : IQuery<Result<List<ProductResponse>>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}

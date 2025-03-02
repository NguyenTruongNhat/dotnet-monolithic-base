using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Abstractions.Shared;
using MonolithicBase.Contract.Enumerations;
using static MonolithicBase.Contract.Services.V1.Product.Response;

namespace MonolithicBase.Contract.Services.V1.Product;

public static class Query
{
    public record GetProductsQuery(string? SearchTerm, string? SortColumn, SortOrder? SortOrder, IDictionary<string, SortOrder>? SortColumnAndOrder, int PageIndex, int PageSize) : IQuery<PagedResult<ProductResponse>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}

using AutoMapper;
using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Abstractions.Shared;
using MonolithicBase.Contract.Services.V2.Product;
using MonolithicBase.Domain.Abstractions.Dappers;

namespace MonolithicBase.Application.UserCases.V2.Queries.Product;

public sealed class GetProductsQueryHandler : IQueryHandler<Query.GetProductsQuery, Result<List<Response.ProductResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Result<List<Response.ProductResponse>>>> Handle(Query.GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        var results = _mapper.Map<List<Response.ProductResponse>>(products);

        return Result.Success(results);
    }
}

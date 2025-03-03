using AutoMapper;
using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Abstractions.Shared;
using MonolithicBase.Contract.Services.V2.Product;
using MonolithicBase.Domain.Abstractions.Dappers;
using MonolithicBase.Domain.Exceptions;

namespace MonolithicBase.Application.UserCases.V2.Queries.Product;

public sealed class GetProductByIdQueryHandler : IQueryHandler<Query.GetProductByIdQuery, Response.ProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Response.ProductResponse>> Handle(Query.GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        var result = _mapper.Map<Response.ProductResponse>(product);

        return Result.Success(result);
    }
}

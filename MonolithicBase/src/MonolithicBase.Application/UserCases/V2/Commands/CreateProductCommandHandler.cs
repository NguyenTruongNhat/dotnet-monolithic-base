using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Abstractions.Shared;
using MonolithicBase.Contract.Services.V2.Product;
using MonolithicBase.Domain.Abstractions.Dappers;

namespace MonolithicBase.Application.UserCases.V2.Commands;

public sealed class CreateProductCommandHandler : ICommandHandler<Command.CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Domain.Entities.Product.CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Description);

        var result = await _unitOfWork.Products.AddAsync(product);

        return Result.Success(result);
    }
}

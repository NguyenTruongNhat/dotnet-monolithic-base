using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Abstractions.Shared;
using MonolithicBase.Contract.Services.V2.Product;
using MonolithicBase.Domain.Abstractions.Dappers;
using MonolithicBase.Domain.Exceptions;

namespace MonolithicBase.Application.UserCases.V2.Commands;

public sealed class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        product.Update(request.Name, request.Price, request.Description);

        var result = await _unitOfWork.Products.UpdateAsync(product);

        return Result.Success(result);
    }
}

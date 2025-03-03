using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Abstractions.Shared;
using MonolithicBase.Contract.Services.V2.Product;
using MonolithicBase.Domain.Abstractions.Dappers;
using MonolithicBase.Domain.Exceptions;

namespace MonolithicBase.Application.UserCases.V2.Commands;

public sealed class DeleteProductCommandHandler : ICommandHandler<Command.DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        var result = await _unitOfWork.Products.DeleteAsync(product.Id);

        return Result.Success(result);
    }
}

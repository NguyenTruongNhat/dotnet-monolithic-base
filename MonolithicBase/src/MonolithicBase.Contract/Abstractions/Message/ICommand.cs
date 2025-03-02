using MediatR;
using MonolithicBase.Contract.Abstractions.Shared;

namespace MonolithicBase.Contract.Abstractions.Message;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}

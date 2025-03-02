using MediatR;
using MonolithicBase.Contract.Abstractions.Shared;

namespace MonolithicBase.Contract.Abstractions.Message;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }

using MediatR;
using MonolithicBase.Contract.Abstractions.Shared;

namespace MonolithicBase.Contract.Abstractions.Message;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{ }

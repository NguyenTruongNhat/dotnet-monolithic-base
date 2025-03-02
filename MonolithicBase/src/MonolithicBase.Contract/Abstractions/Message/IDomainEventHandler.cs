using MediatR;

namespace MonolithicBase.Contract.Abstractions.Message;
public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}

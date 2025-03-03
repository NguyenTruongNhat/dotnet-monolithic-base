using MonolithicBase.Contract.Abstractions.Message;

namespace MonolithicBase.Contract.Services.V2.Product;

public static class DomainEvent
{
    public record ProductCreated(Guid Id) : IDomainEvent;
    public record ProductDeleted(Guid Id) : IDomainEvent;
    public record ProductUpdated(Guid Id) : IDomainEvent;
}

using MonolithicBase.Contract.Abstractions.Message;
using MonolithicBase.Contract.Services.V1.Product;

namespace MonolithicBase.Application.UserCases.V1.Events;

internal class SendEmailWhenProductChangedEventHandler
    : IDomainEventHandler<DomainEvent.ProductCreated>,
    IDomainEventHandler<DomainEvent.ProductDeleted>
{
    public async Task Handle(DomainEvent.ProductCreated notification, CancellationToken cancellationToken)
    {
        SendEmail();
        await Task.Delay(100000);
    }

    public async Task Handle(DomainEvent.ProductDeleted notification, CancellationToken cancellationToken)
    {
        SendEmail();
        await Task.Delay(100000);
    }

    private void SendEmail()
    {

    }
}

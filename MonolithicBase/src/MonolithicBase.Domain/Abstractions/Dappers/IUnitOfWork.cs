using MonolithicBase.Domain.Abstractions.Dappers.Repositories.Product;

namespace MonolithicBase.Domain.Abstractions.Dappers;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
}

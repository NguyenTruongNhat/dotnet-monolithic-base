
using MonolithicBase.Domain.Abstractions.Dappers;
using MonolithicBase.Domain.Abstractions.Dappers.Repositories.Product;

namespace MonolithicBase.Infrastructure.Dapper;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IProductRepository productRepository)
    {
        Products = productRepository;
    }

    public IProductRepository Products { get; }
}

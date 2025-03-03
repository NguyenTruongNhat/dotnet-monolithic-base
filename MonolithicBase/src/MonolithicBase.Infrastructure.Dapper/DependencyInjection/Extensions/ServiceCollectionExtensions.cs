using Microsoft.Extensions.DependencyInjection;
using MonolithicBase.Domain.Abstractions.Dappers;
using MonolithicBase.Domain.Abstractions.Dappers.Repositories.Product;
using MonolithicBase.Infrastructure.Dapper.Repositories;


namespace MonolithicBase.Infrastructure.Dapper.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureDapper(this IServiceCollection services)
        => services.AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IUnitOfWork, UnitOfWork>();
}

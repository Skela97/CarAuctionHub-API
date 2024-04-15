using AuctionService.Application.Contracts;
using AuctionService.Common.Interfaces;
using AuctionService.Infrastructure.EntityFramework.Context;
using AuctionService.Infrastructure.EntityFramework.Repositories;

namespace AuctionService.Infrastructure.EntityFramework;

public static class DIConfiguration
{
    public static IServiceCollection AddEntityFrameworkDependencies(this IServiceCollection services)
    {
        return services.AddServices().AddRepositories();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddTransient<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAuctionRepository, AuctionRepository>();

        return services;
    }
}
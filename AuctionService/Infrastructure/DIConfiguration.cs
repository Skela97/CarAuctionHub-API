using AuctionService.Infrastructure.EntityFramework;
using AuctionService.Infrastructure.MassTransit;

namespace AuctionService.Infrastructure;

public static class DIConfiguration
{
    public static IServiceCollection AddInfrastructuralDependencies(this IServiceCollection services)
    {
        return services.AddMassTransitDependencies().AddEntityFrameworkDependencies();
    }
}
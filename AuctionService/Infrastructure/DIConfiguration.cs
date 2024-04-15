using AuctionService.Infrastructure.EntityFramework;

namespace AuctionService.Infrastructure;

public static class DIConfiguration
{
    public static IServiceCollection AddInfrastructuralDependencies(this IServiceCollection services)
    {
        return services.AddEntityFrameworkDependencies();
    }
}
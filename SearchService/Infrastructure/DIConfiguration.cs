using SearchService.Infrastructure.MassTransit;
using SearchService.Infrastructure.MongoDb;

namespace SearchService.Infrastructure;

public static class DIConfiguration
{
    public static IServiceCollection AddInfrastructuralDependencies(this IServiceCollection services)
    {
        return services.AddMongoDbDependencies().AddMassTransitDependencies();
    }
}

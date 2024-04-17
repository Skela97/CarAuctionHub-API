using SearchService.Application.Contracts;
using SearchService.Infrastructure.MongoDb.Repositories;

namespace SearchService.Infrastructure.MongoDb;

public static class DIConfiguration
{
    public static IServiceCollection AddMongoDbDependencies(this IServiceCollection services)
    {
        return services.AddTransient<IItemRepository,ItemRepository>();
    }
}


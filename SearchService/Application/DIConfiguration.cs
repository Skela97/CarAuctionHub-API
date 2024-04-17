using AuctionService.Common.Interfaces;
using SearchService.Application.UseCases.SearchItems;

namespace SearchService.Application;

public static class DIConfiguration
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        return services.AddTransient<IUseCase<SearchItemsRequest,SearchItemsResponse>, SearchItemsUseCase>();
    }
}


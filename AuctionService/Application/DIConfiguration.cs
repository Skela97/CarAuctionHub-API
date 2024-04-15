using AuctionService.Application.UseCases.Auctions.Create;
using AuctionService.Application.UseCases.Auctions.Delete;
using AuctionService.Application.UseCases.Auctions.Get;
using AuctionService.Application.UseCases.Auctions.GetAll;
using AuctionService.Application.UseCases.Auctions.Update;
using AuctionService.Common.Interfaces;

namespace AuctionService.Application;

public static class DIConfiguration
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        return AddUseCases(services);
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<IUseCase<GetAllAuctionsRequest, GetAllAuctionsResponse>, GetAllAuctionsUseCase>();
        services.AddTransient<IUseCase<GetAuctionRequest, GetAuctionResponse>, GetAuctionUseCase>();
        services.AddTransient<IUseCase<CreateAuctionRequest, CreateAuctionResponse>, CreateAuctionUseCase>();
        services.AddTransient<IUseCase<UpdateAuctionRequest, UpdateAuctionResponse>, UpdateAuctionUseCase>();
        services.AddTransient<IUseCase<DeleteAuctionRequest, DeleteAuctionResponse>, DeleteAuctionUseCase>(); 
         
        return services;
    }
}
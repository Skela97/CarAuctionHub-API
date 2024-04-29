using AuctionService.Application.Contracts.Publishers;
using AuctionService.Infrastructure.EntityFramework;
using AuctionService.Infrastructure.MassTransit.Publishers;
using MassTransit;

namespace AuctionService.Infrastructure.MassTransit;

public static class DIConfiguration
{
    public static IServiceCollection AddMassTransitDependencies(this IServiceCollection  services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddTransient<IAuctionPublisher, AuctionPublisher>();

        return services;
    }
}

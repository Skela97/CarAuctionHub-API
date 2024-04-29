using MassTransit;
using SearchService.Infrastructure.MassTransit.Consumer;

namespace SearchService.Infrastructure.MassTransit;

public static class DIConfiguration
{
    public static IServiceCollection AddMassTransitDependencies(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<AuctionCreatedConsumer>();
            x.AddConsumer<AuctionUpdatedConsumer>();
            x.AddConsumer<AuctionDeletedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
  
using AuctionService.Application.Contracts.Publishers;
using AuctionService.Domain;
using Contracts;
using MassTransit;

namespace AuctionService.Infrastructure.MassTransit.Publishers;

public class AuctionPublisher : IAuctionPublisher
{
    private readonly IPublishEndpoint endpoint;

    public AuctionPublisher(IPublishEndpoint endpoint)
    {
        this.endpoint = endpoint;
    }
    
    public async Task PublishCreatedAsync(Auction auction)
    {
        await endpoint.Publish(FormAuctionCreatedMessage(auction));
    }

    public async Task PublishUpdatedAsync(Auction auction)
    {
        await endpoint.Publish(FormAuctionUpdatedMessage(auction));
    }

    public async Task PublishDeletedAsync(Auction auction)
    {
        await endpoint.Publish(FormAuctionDeletedMessage(auction));
    }

    private static AuctionCreated FormAuctionCreatedMessage(Auction auction)
    {
        return new AuctionCreated(
            auction.Id,
            auction.ReservePrice,
            auction.Seller,
            auction.Winner,
            auction.SoldAmount,
            auction.CurrentHighBid,
            auction.Status,
            auction.CreatedAt,
            auction.UpdatedAt,
            auction.AuctionEnd,
            auction.Item.Make,
            auction.Item.Model,
            auction.Item.Year,
            auction.Item.Color,
            auction.Item.Mileage,
            auction.Item.ImageUrl);
    }

    private static AuctionUpdated FormAuctionUpdatedMessage(Auction auction)
    {
        return new AuctionUpdated(
            auction.Id,
            auction.Item.Make,
            auction.Item.Model,
            auction.Item.Year,
            auction.Item.Color,
            auction.Item.Mileage);
    }
    private static AuctionDeleted FormAuctionDeletedMessage(Auction auction)
    {
        return new AuctionDeleted(auction.Id);
    }
}

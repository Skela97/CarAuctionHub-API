using AuctionService.Domain;

namespace AuctionService.Application.Contracts.Publishers;

public interface IAuctionPublisher
{
    public Task PublishCreatedAsync(Auction auction);
    public Task PublishDeletedAsync(Auction auction);
    public Task PublishUpdatedAsync(Auction auction);  
}

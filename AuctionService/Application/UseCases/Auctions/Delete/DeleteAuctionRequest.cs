namespace AuctionService.Application.UseCases.Auctions.Delete;

public class DeleteAuctionRequest
{
    public Guid Id { get; set; }

    public DeleteAuctionRequest(Guid id)
    {
        Id = id;
    }
}
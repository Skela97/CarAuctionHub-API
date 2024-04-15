namespace AuctionService.Application.UseCases.Auctions.Get;

public class GetAuctionRequest
{
    public Guid Id { get; set; }

    public GetAuctionRequest(Guid id)
    {
        Id = id;
    }
    
}
namespace AuctionService.Application.UseCases.Auctions.Delete;

public class DeleteAuctionRequest
{
    public Guid Id { get; set; }

    public string? Seller { get; set; }

    public DeleteAuctionRequest(Guid id, string? seller)
    {
        Id = id;
        Seller = seller;    
    }
}
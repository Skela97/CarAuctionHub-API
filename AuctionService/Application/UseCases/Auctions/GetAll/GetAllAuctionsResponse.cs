using AuctionService.Domain;

namespace AuctionService.Application.UseCases.Auctions.GetAll;

public class GetAllAuctionsResponse
{
    public GetAllAuctionsResponse(IEnumerable<Auction> auctions)
    {
        Auctions = auctions;
    }
    
    public IEnumerable<Auction> Auctions { get; set; }
}
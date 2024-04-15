using AuctionService.Domain;

namespace AuctionService.Application.UseCases.Auctions.Get;

public class GetAuctionResponse
{
     public GetAuctionResponse(Auction auction)
        {
            Auction = auction;
        }
    
    public Auction Auction { get; set; }
}
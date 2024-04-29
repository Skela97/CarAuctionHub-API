using AuctionService.Domain;
using AuctionService.Presentation.Models.Response;

namespace AuctionService.Presentation.Mapper;

public static class AuctionMapper
{
    public static IEnumerable<AuctionViewModel> MapAuctionsResponse(IEnumerable<Auction> auctions)
    {
        return auctions.Select(MapAuctionResponse);
    }
    
    public static AuctionViewModel MapAuctionResponse(Auction auction)
    {
        return new AuctionViewModel(
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
            auction.Item.ImageUrl
        );
    }
}
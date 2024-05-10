using AuctionService.Application.UseCases.Auctions.Create;

namespace AuctionService.Application.Extensions;

public static class CreateAuctionRequestExtension
{
    public static CreateAuctionRequest AppendWithSeller(this CreateAuctionRequest auctionRequest, string? seller)
    {
        auctionRequest.Seller = seller;

        return auctionRequest;
    }
}

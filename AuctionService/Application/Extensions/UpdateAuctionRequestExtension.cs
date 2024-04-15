using AuctionService.Application.UseCases.Auctions.Update;

namespace AuctionService.Application.Extensions;

public static class UpdateAuctionRequestExtension
{
    public static UpdateAuctionRequest AppendWithId(this UpdateAuctionRequest auctionRequest, Guid id)
    {
        auctionRequest.Id = id;

        return auctionRequest;
    }
}
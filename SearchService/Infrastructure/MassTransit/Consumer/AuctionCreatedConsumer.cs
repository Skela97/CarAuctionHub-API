using Contracts;
using MassTransit;
using SearchService.Application.Contracts;
using SearchService.Domain;
using SearchService.Infrastructure.MassTransit.Exceptions;

namespace SearchService.Infrastructure.MassTransit.Consumer;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IAuctionRepository auctionRepository;

    public AuctionCreatedConsumer(IAuctionRepository auctionRepository)
    {
        this.auctionRepository = auctionRepository;
    }
           
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        AuctionCreated inputAuction = context.Message;

        if (inputAuction == null) throw new MessageParsingFailedException();

        await auctionRepository.AddAsync(FormAuction(inputAuction));
    }

    public Auction FormAuction(AuctionCreated inputAuction)
    {
        return new Auction(
            inputAuction.Id,
            inputAuction.ReservePrice,
            inputAuction.Seller,
            inputAuction.Winner,
            inputAuction.SoldAmount,
            inputAuction.CurrentHighBid,
            inputAuction.Status,
            inputAuction.CreatedAt,
            inputAuction.UpdatedAt,
            inputAuction.AuctionEnd,
            inputAuction.Make,
            inputAuction.Model,
            inputAuction.Year,
            inputAuction.Color,
            inputAuction.Mileage,
            inputAuction.ImageUrl);
    }
}

using Contracts;
using MassTransit;
using SearchService.Application.Contracts;
using SearchService.Domain;
using SearchService.Infrastructure.MassTransit.Exceptions;

namespace SearchService.Infrastructure.MassTransit.Consumer;

public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
{
    private readonly IAuctionRepository auctionRepository;

    public AuctionUpdatedConsumer(IAuctionRepository auctionRepository)
    {
        this.auctionRepository = auctionRepository;
    }

    public async Task Consume(ConsumeContext<AuctionUpdated> context)
    {
        AuctionUpdated inputAuction = context.Message;
        if (inputAuction == null) throw new MessageParsingFailedException();

        Auction? auction = await auctionRepository.GetAsync(inputAuction.Id);
        if (auction == null) throw new AuctionNotFoundException();

        auction.Update(inputAuction.Make, inputAuction.Model, inputAuction.Year, inputAuction.Color, inputAuction.Mileage);
        await auctionRepository.UpdateAsync(auction);
    }
}

using Contracts;
using MassTransit;
using SearchService.Application.Contracts;
using SearchService.Domain;
using SearchService.Infrastructure.MassTransit.Exceptions;

namespace SearchService.Infrastructure.MassTransit.Consumer;

public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
{
    private readonly IAuctionRepository auctionRepository;

    public AuctionDeletedConsumer(IAuctionRepository auctionRepository)
    {
        this.auctionRepository = auctionRepository;
    }

    public async Task Consume(ConsumeContext<AuctionDeleted> context)
    {
        AuctionDeleted inputAuction = context.Message;
        if (inputAuction == null) throw new MessageParsingFailedException();

        Auction? auction = await auctionRepository.GetAsync(inputAuction.Id);
        if (auction == null) throw new AuctionNotFoundException();

        await auctionRepository.DeleteAsync(auction);
    }
}

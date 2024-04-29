namespace SearchService.Infrastructure.MassTransit.Exceptions;

public class AuctionNotFoundException : Exception
{
    public AuctionNotFoundException():base("Auction could not be find for the provided id.")
    {
    }
}

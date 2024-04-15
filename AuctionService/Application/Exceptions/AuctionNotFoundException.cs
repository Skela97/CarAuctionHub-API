namespace AuctionService.Application.Exceptions;

public class AuctionNotFoundException : Exception
{
    public AuctionNotFoundException() : base("Auction couldn't be found with the given ID.")
    {
    }
}
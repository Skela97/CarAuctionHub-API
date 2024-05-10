namespace AuctionService.Application.Exceptions;

public class AuctionChangeNotAuthorizedException : Exception
{
    public AuctionChangeNotAuthorizedException(string message) : base(message)
    {
    }
}

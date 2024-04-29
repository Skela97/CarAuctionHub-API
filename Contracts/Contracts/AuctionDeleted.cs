namespace Contracts;

public class AuctionDeleted
{
    public AuctionDeleted(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}

namespace AuctionService.Common.Interfaces;

public interface IUnitOfWork
{
    public Task BeginTransactionAsync();
    public Task CommitAsync();
}
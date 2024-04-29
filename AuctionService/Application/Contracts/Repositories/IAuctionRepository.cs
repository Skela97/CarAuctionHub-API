using AuctionService.Domain;

namespace AuctionService.Application.Contracts;

public interface IAuctionRepository
{
    public Task<IEnumerable<Auction>> GetAllAsync();
    public Task<Auction?> GetByIdAsync(Guid id);
    public Task AddAsync(Auction auction);
    public Task DeleteAsync(Auction auction);
}
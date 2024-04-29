using AuctionService.Application.Contracts;
using AuctionService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Infrastructure.EntityFramework.Repositories;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionDbContext _context;

    public AuctionRepository(AuctionDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Auction>> GetAllAsync()
    {
        return await _context.Auctions.Include(a=>a.Item).ToListAsync();
    }
    
    public async Task<Auction?> GetByIdAsync(Guid id)
    {
        return await _context.Auctions.Where(a => a.Id == id).Include(a=>a.Item).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Auction auction)
    {
        await _context.AddAsync(auction);
    }

    public Task DeleteAsync(Auction auction)
    {
        _context.Auctions.Remove(auction);

        return Task.CompletedTask;
    }
}
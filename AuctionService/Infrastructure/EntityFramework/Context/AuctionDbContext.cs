using AuctionService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Infrastructure.EntityFramework;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Auction> Auctions { get; set; }
}
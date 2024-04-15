using AuctionService.Domain;
using AuctionService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Infrastructure.EntityFramework.Initializer;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>() ?? throw new InvalidOperationException());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();
        if (context.Auctions.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        IEnumerable<Auction> auctions = GenerateSeedAuctions();
        
        context.AddRange(auctions);
        context.SaveChanges();
    }

    private static List<Auction> GenerateSeedAuctions()
    {
        return new List<Auction>()
        {
            new Auction(
                Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                20000,
                new Item(
                    Guid.Parse("8238adb8-f047-4351-bc4e-5d8b3e597080"),
                    "ford",
                    "GT",
                    2020,
                    "white",
                    50000,
                    "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg"),
                "bob",
                null,
                null,
                null,
                Status.Live,
                DateTime.UtcNow.AddDays(60)
                ),
            
            new Auction(
                Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                90000,
                new Item(
                    Guid.Parse("8238adb8-f047-4351-bc4e-5d8b3e597081"),
                    "Bugatti",
                    "Veyron",
                    2018,
                    "Black",
                    15035,
                    "https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg"),
                "alice",
                null,
                null,
                null,
                Status.Live,
                DateTime.UtcNow.AddDays(60)
            ),
        };
    }
}
using AuctionService.Domain.Enums;

namespace Contracts;

public class AuctionCreated
{
    public Guid Id { get; set; }
    public int ReservePrice { get; set; }
    public string? Seller { get; set; }
    public string? Winner { get; set; }
    public int? SoldAmount { get; set; }
    public int? CurrentHighBid { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Mileage { get; set; }
    public string ImageUrl { get; set; }

    public AuctionCreated(
        Guid id, 
        int reservePrice,
        string? seller,
        string? winner, 
        int? soldAmount,
        int? currentHighBid, 
        Status status, 
        DateTime createdAt, 
        DateTime updatedAt,
        DateTime auctionEnd, 
        string make,
        string model,
        int year, 
        string color, 
        int mileage, 
        string imageUrl)
    {
        Id = id;
        ReservePrice = reservePrice;
        Seller = seller;
        Winner = winner;
        SoldAmount = soldAmount;
        CurrentHighBid = currentHighBid;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        AuctionEnd = auctionEnd;
        Make = make;
        Model = model;
        Year = year;
        Color = color;
        Mileage = mileage;
        ImageUrl = imageUrl;
    }
}

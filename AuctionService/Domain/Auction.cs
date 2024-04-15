using System.ComponentModel.DataAnnotations.Schema;
using AuctionService.Domain.Enums;

namespace AuctionService.Domain;

[Table("Auctions")]
public class Auction
{
    public Guid Id { get; private set; }
    public int ReservePrice { get; private set; }
    public Item Item { get; private set; }
    public string? Seller { get; private set; }
    public string? Winner { get; private set; } 
    public int? SoldAmount { get; private set; }
    public int? CurrentHighBid { get; private set; }
    public Status Status { get; private set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime AuctionEnd { get; set; }

    public Auction(
        Guid id,
        int reservePrice, 
        Item item, 
        string? seller, 
        string? winner, 
        int? soldAmount, 
        int? currentHighBid, 
        Status status, 
        DateTime auctionEnd)
    {
        Id = id;
        ReservePrice = reservePrice;
        Item = item;
        Seller = seller;
        Winner = winner;
        SoldAmount = soldAmount;
        CurrentHighBid = currentHighBid;
        Status = status;
        AuctionEnd = auctionEnd;
    }

    public Auction()
    {
    }

    public void Update(string? make, string? model, int? year, string? color, int? mileage)
    {
        if (make != null) Item.Make = make;
        if (model != null) Item.Model = model;
        if (year != null) Item.Year = year.Value;
        if (color != null) Item.Color = color;
        if (mileage != null) Item.Mileage = mileage.Value;
    }
}
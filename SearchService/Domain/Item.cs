using AuctionService.Domain.Enums;
using MongoDB.Entities;

namespace SearchService.Domain
{
    public class Item : Entity
    {
        public int ReservePrice { get; private set; }
        public string? Seller { get; private set; }
        public string? Winner { get; private set; }
        public int? SoldAmount { get; private set; }
        public int? CurrentHighBid { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime AuctionEnd { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Color { get; private set; }
        public int Mileage { get; private set; }
        public string ImageUrl { get; private set; }

        public Item(
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
}

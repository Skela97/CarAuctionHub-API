using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Domain;

[Table("Items")]
public class Item
{
    public Item(
        Guid id,
        string make, 
        string model, 
        int year, 
        string color, 
        int mileage, 
        string imageUrl)
    {
        Id = id;
        Make = make;
        Model = model;
        Year = year;
        Color = color;
        Mileage = mileage;
        ImageUrl = imageUrl;
    }

    public Item()
    {
    }
    
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Mileage { get; set; }
    public string ImageUrl { get; set; }
    
    // navigiation properties
    public Auction? Auction { get; set; }
    public Guid AuctionId { get; set; }
}
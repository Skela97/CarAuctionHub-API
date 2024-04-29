namespace Contracts;

public class AuctionUpdated
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Mileage { get; set; }

    public AuctionUpdated(
        Guid id,
        string make, 
        string model, 
        int year,
        string color, 
        int mileage)
    {
        Id = id;
        Make = make;
        Model = model;
        Year = year;
        Color = color;
        Mileage = mileage;
    }
}

﻿namespace AuctionService.Application.UseCases.Auctions.Update;

public class UpdateAuctionRequest
{
    public Guid? Id { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? Color { get; set; }
    public int? Mileage { get; set; }

    public string? Seller { get; set; }

    public UpdateAuctionRequest()
    {
    }
}
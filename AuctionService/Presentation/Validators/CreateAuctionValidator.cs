using System.Data;
using AuctionService.Application.UseCases.Auctions.Create;
using FluentValidation;

namespace AuctionService.Presentation.Validators;

public class CreateAuctionValidator : AbstractValidator<CreateAuctionRequest>
{
    public CreateAuctionValidator()
    {
        RuleFor(r => r.ReservePrice).NotEmpty();
        RuleFor(r => r.ImageUrl).NotEmpty();
        RuleFor(r => r.Color).NotEmpty();
        RuleFor(r => r.Make).NotEmpty();
        RuleFor(r => r.Mileage).NotEmpty();
        RuleFor(r => r.Model).NotEmpty();
        RuleFor(r => r.Year).NotEmpty();
        RuleFor(r => r.AuctionEnd).NotEmpty();
    }
}
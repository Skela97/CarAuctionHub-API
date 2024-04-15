using AuctionService.Application.UseCases.Auctions.Update;
using FluentValidation;

namespace AuctionService.Presentation.Validators;

public class UpdateAuctionValidator : AbstractValidator<UpdateAuctionRequest>
{
    public UpdateAuctionValidator()
    {
        RuleFor(r => r)
            .Must(HasNotNullProperty)
            .WithMessage("Please enter the value for any of the possible fields.");
    }

    private bool HasNotNullProperty(UpdateAuctionRequest r)
    {
        return r.Model != null || r.Make != null || r.Year != null || r.Color != null || r.Mileage != null;
    }
}
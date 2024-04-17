using FluentValidation;
using SearchService.Application.UseCases.SearchItems;

namespace SearchService.Presentation.Validators;

public class SearchItemsRequestValidator : AbstractValidator<SearchItemsRequest>
{
    public SearchItemsRequestValidator()
    {
        RuleFor(r=>r.Page).GreaterThanOrEqualTo(1); 
        RuleFor(r=>r.PageSize).GreaterThanOrEqualTo(1);
    }
}

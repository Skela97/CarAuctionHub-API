using SearchService.Common.Request;
using SearchService.Presentation.Models;

namespace SearchService.Application.UseCases.SearchItems;

public class SearchItemsRequest : SearchRequest<SearchFilters>
{
    public string? SearchTerm { get; set; }
}

using SearchService.Application.UseCases.SearchItems;
using SearchService.Domain;

namespace SearchService.Application.Contracts;

public interface IItemRepository
{
    public Task<SearchItemsResponse> SearchItemsAsync(SearchItemsRequest request);
}

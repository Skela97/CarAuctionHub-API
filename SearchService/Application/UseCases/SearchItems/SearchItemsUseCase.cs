using AuctionService.Common.Interfaces;
using SearchService.Application.Contracts;

namespace SearchService.Application.UseCases.SearchItems;

public class SearchItemsUseCase : IUseCase<SearchItemsRequest, SearchItemsResponse>
{
    private readonly IItemRepository repository;

    public SearchItemsUseCase(IItemRepository repository )
    {
        this.repository = repository;
    }

    public async Task<SearchItemsResponse> ExecuteAsync(SearchItemsRequest request)
    {
        return await repository.SearchItemsAsync(request);
    }
}

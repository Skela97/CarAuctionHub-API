using SearchService.Application.UseCases.SearchItems;
using SearchService.Domain;

namespace SearchService.Application.Contracts;

public interface IAuctionRepository
{
    public Task<SearchItemsResponse> SearchItemsAsync(SearchItemsRequest request);
    public Task<Auction?> GetAsync(Guid id);
    public Task AddAsync(Auction auction);
    public Task UpdateAsync(Auction auction);
    public Task DeleteAsync(Auction auction);
}

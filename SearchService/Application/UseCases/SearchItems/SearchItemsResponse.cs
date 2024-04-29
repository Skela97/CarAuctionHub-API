using SearchService.Domain;

namespace SearchService.Application.UseCases.SearchItems;

public class SearchItemsResponse
{
    public SearchItemsResponse(IEnumerable<Auction> items, long count)
    {
        Items = items;
        Count = count;
    }

    public IEnumerable<Auction> Items { get; set; }
    public long Count { get; set; }
}

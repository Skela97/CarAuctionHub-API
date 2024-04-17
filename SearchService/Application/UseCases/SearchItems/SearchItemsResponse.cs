using SearchService.Domain;

namespace SearchService.Application.UseCases.SearchItems;

public class SearchItemsResponse
{
    public SearchItemsResponse(IEnumerable<Item> items, long count)
    {
        Items = items;
        Count = count;
    }

    public IEnumerable<Item> Items { get; set; }
    public long Count { get; set; }
}

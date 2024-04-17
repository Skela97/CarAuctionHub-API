namespace SearchService.Common.Request;

public class SearchRequest<T>
{
    public T? SearchFilters { get; set; } 
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchColumn { get; set; }
    public SearchDirection SearchDirection { get; set; } = SearchDirection.DESC;
}

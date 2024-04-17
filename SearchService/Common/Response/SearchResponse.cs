namespace SearchService.Common.Response;

public class SearchResponse<T>
{
    public IEnumerable<T> Data { set; get; } = new LinkedList<T>();  
    public long Count { get; set; } = 0;
}

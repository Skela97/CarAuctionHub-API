namespace SearchService.Presentation.Models;

public class SearchFilters
{
    public string? Winner { get; set; }
    public string? Seller { get; set; }
    public DateTime? AuctionEndFrom { get;set; }
    public DateTime? AuctionEndTo { get; set; }
}

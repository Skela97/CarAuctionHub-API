using MongoDB.Entities;
using SearchService.Application.Contracts;
using SearchService.Application.Exceptions;
using SearchService.Application.UseCases.SearchItems;
using SearchService.Domain;

namespace SearchService.Infrastructure.MongoDb.Repositories;

public class AuctionRepository : IAuctionRepository
{
    private const string CREATED_AT_COLUMN_NAME = "CreatedAt";
    private const string MAKE_COLUMN_NAME = "Make";

    public async Task<SearchItemsResponse> SearchItemsAsync(SearchItemsRequest request)
    {
        PagedSearch<Auction> query = DB.PagedSearch<Auction>();

        AddSorting(request, query);
        AddFiltering(request, query);
        AddPagination(request, query);
        AddSearchTermFiltering(request, query);

        (IReadOnlyList<Auction> Results, long TotalCount, int PageCount) results =  await query.ExecuteAsync();

        return new SearchItemsResponse(results.Results, results.TotalCount);
    }

    public async Task<Auction?> GetAsync(Guid id)
    {
        return await DB.Find<Auction>().OneAsync(id.ToString());
    }

    public async Task AddAsync(Auction auction)
    {
        await auction.SaveAsync();
    }

    public async Task UpdateAsync(Auction auction)
    {
        await DB.Update<Auction>()
        .MatchID(auction.ID)
        .ModifyWith(auction)
        .ExecuteAsync();
    }

    public async Task DeleteAsync(Auction auction)
    {
        await auction.DeleteAsync();
    }

    private void AddSorting(SearchItemsRequest request, PagedSearch<Auction> query)
    {
        if (string.IsNullOrEmpty(request.SearchColumn))
        {
            query.Sort(x => x.Ascending(r => r.AuctionEnd));
            return;
        }

        if (request.SearchDirection == Common.Request.SearchDirection.ASC)
        {
            if (request.SearchColumn == CREATED_AT_COLUMN_NAME)
            {
                query.Sort(x => x.Ascending(a => a.CreatedAt));
                return;
            }

            if(request.SearchColumn == MAKE_COLUMN_NAME)
            {
                query.Sort(x => x.Ascending(a => a.Make));
                return;
            }
        }

        if (request.SearchDirection == Common.Request.SearchDirection.DESC)
        {
            if (request.SearchColumn == CREATED_AT_COLUMN_NAME)
            {
                query.Sort(x => x.Descending(a => a.CreatedAt));
                return;
            }

            if (request.SearchColumn == MAKE_COLUMN_NAME)
            {
                query.Sort(x => x.Descending(a => a.Make));
                return;
            }
        }

        throw new ColumnNotSupportedException(request.SearchColumn);
    }

    private void AddSearchTermFiltering(SearchItemsRequest request, PagedSearch<Auction> query)
    {
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query.Match(Search.Full, request.SearchTerm).SortByTextScore();
        }
    }

    private void AddFiltering(SearchItemsRequest request, PagedSearch<Auction> query)
    {
        if(request?.SearchFilters?.AuctionEndFrom != null)
        {
            query.Match(a => a.AuctionEnd > request.SearchFilters.AuctionEndFrom);
        }

        if(request?.SearchFilters?.AuctionEndTo !=null)
        {
            query.Match(a => a.AuctionEnd < request.SearchFilters.AuctionEndTo);
        }

        if(!string.IsNullOrEmpty(request?.SearchFilters?.Winner))
        {
            query.Match(a => a.Winner == request.SearchFilters.Winner);   
        }

        if (!string.IsNullOrEmpty(request?.SearchFilters?.Seller))
        {
            query.Match(a => a.Seller == request.SearchFilters.Seller);
        }
    }

    private void AddPagination(SearchItemsRequest request, PagedSearch<Auction> query)
    {
        query.PageNumber(request.Page);
        query.PageSize(request.PageSize);
    }
}
   

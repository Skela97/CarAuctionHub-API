using AuctionService.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SearchService.Application.UseCases.SearchItems;
using SearchService.Common.Response;
using SearchService.Domain;
using SearchService.Presentation.Models.Response;

namespace SearchService.Presentation;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<SearchItemsResponseModel> SearchItems(
        [FromQuery] SearchItemsRequest request,
        [FromServices] IUseCase<SearchItemsRequest, SearchItemsResponse> useCase)
    {
        SearchItemsResponse response = await useCase.ExecuteAsync(request);

        return new SearchItemsResponseModel()
        {
            Data = response.Items,
            Count = response.Count
        };
    }
}

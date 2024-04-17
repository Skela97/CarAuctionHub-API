using AuctionService.Application.Extensions;
using AuctionService.Application.UseCases.Auctions.Create;
using AuctionService.Application.UseCases.Auctions.Delete;
using AuctionService.Application.UseCases.Auctions.Get;
using AuctionService.Application.UseCases.Auctions.GetAll;
using AuctionService.Application.UseCases.Auctions.Update;
using AuctionService.Common.Interfaces;
using AuctionService.Domain;
using AuctionService.Presentation.Mapper;
using AuctionService.Presentation.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Presentation.Controllers;

[ApiController]
[Route("api/auctions")]
public class AuctionsController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<AuctionViewModel>> GetAllAuctions(
        [FromServices] IUseCase<GetAllAuctionsRequest,GetAllAuctionsResponse> useCase)
    {
        GetAllAuctionsResponse response = await useCase.ExecuteAsync(new GetAllAuctionsRequest());

        return AuctionMapper.MapAuctionsResponse(response.Auctions);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<AuctionViewModel> Get(
        [FromServices] IUseCase<GetAuctionRequest,GetAuctionResponse> useCase,
        [FromRoute] Guid id)
    {
        GetAuctionResponse response= await useCase.ExecuteAsync(new GetAuctionRequest(id));

        return AuctionMapper.MapAuctionResponse(response.Auction);
    }
    
    [HttpPost]
    public async Task CreateAuction(
        [FromBody] CreateAuctionRequest request,
        [FromServices] IUseCase<CreateAuctionRequest,CreateAuctionResponse> useCase)
    {
        await useCase.ExecuteAsync(request);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task UpdateAuction(
        [FromBody] UpdateAuctionRequest request,
        [FromServices] IUseCase<UpdateAuctionRequest, UpdateAuctionResponse> useCase,
        [FromRoute] Guid id)
    {
        await useCase.ExecuteAsync(request.AppendWithId(id));
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task DeleteAuction(
        [FromServices] IUseCase<DeleteAuctionRequest, DeleteAuctionResponse> useCase,
        [FromRoute] Guid id)
    {
        await useCase.ExecuteAsync(new DeleteAuctionRequest(id));
    }
}
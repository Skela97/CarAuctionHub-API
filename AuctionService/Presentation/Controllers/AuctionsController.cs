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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuctionService.Presentation.Controllers;

[ApiController]
[Route("api/auctions")]
public class AuctionsController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<AuctionViewModel>> GetAllAuctions(
        [FromServices] IUseCase<GetAllAuctionsRequest,GetAllAuctionsResponse> useCase)
    {
        GetAllAuctionsResponse response = await useCase.ExecuteAsync(new GetAllAuctionsRequest());

        return AuctionMapper.MapAuctionsResponse(response.Auctions);
    }
    
    [HttpGet]
    [Route("{id}")]
    [Authorize]
    public async Task<AuctionViewModel> Get(
        [FromServices] IUseCase<GetAuctionRequest,GetAuctionResponse> useCase,
        [FromRoute] Guid id)
    {
        GetAuctionResponse response= await useCase.ExecuteAsync(new GetAuctionRequest(id));

        return AuctionMapper.MapAuctionResponse(response.Auction);
    }
    
    [HttpPost]
    [Authorize]
    public async Task CreateAuction(
        [FromBody] CreateAuctionRequest request,
        [FromServices] IUseCase<CreateAuctionRequest,CreateAuctionResponse> useCase)
    {
        await useCase.ExecuteAsync(request.AppendWithSeller(GetSeller()));
    }
    
    [HttpPut]
    [Route("{id}")]
    [Authorize]
    public async Task UpdateAuction(
        [FromBody] UpdateAuctionRequest request,
        [FromServices] IUseCase<UpdateAuctionRequest, UpdateAuctionResponse> useCase,
        [FromRoute] Guid id)
    {
        await useCase.ExecuteAsync(request.AppendWithId(id).AppendWithSeller(GetSeller()));
    }
    
    [HttpDelete]
    [Route("{id}")]
    [Authorize]
    public async Task DeleteAuction(
        [FromServices] IUseCase<DeleteAuctionRequest, DeleteAuctionResponse> useCase,
        [FromRoute] Guid id)
    {        
        await useCase.ExecuteAsync(new DeleteAuctionRequest(id, GetSeller()));
    }

    private string? GetSeller()
    {
        ClaimsPrincipal user = HttpContext.User;
        
        return user.FindFirstValue(ClaimTypes.Name);
    }
}
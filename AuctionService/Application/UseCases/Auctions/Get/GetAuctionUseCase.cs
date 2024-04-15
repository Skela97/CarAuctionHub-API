using AuctionService.Application.Contracts;
using AuctionService.Application.Exceptions;
using AuctionService.Common.Interfaces;
using AuctionService.Domain;

namespace AuctionService.Application.UseCases.Auctions.Get;

public class GetAuctionUseCase : IUseCase<GetAuctionRequest, GetAuctionResponse>
{
    private readonly IAuctionRepository _repository;

    public GetAuctionUseCase(IAuctionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<GetAuctionResponse> Execute(GetAuctionRequest request)
    {
        Auction auction = await _repository.GetByIdAsync(request.Id);
        if (auction == null) throw new AuctionNotFoundException(); 
        
        return new GetAuctionResponse(await _repository.GetByIdAsync(request.Id));
    }
}
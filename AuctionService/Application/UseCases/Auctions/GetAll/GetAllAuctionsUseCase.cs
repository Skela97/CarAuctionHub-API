using AuctionService.Application.Contracts;
using AuctionService.Common.Interfaces;

namespace AuctionService.Application.UseCases.Auctions.GetAll;

public class GetAllAuctionsUseCase : IUseCase<GetAllAuctionsRequest, GetAllAuctionsResponse>
{
    private readonly IAuctionRepository _repository;

    public GetAllAuctionsUseCase(IAuctionRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAllAuctionsResponse> ExecuteAsync(GetAllAuctionsRequest request)
    {
        return new GetAllAuctionsResponse(await _repository.GetAllAsync());
    }
}
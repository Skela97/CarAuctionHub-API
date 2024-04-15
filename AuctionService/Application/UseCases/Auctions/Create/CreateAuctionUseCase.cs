using AuctionService.Application.Contracts;
using AuctionService.Common;
using AuctionService.Common.Interfaces;
using AuctionService.Domain;
using AuctionService.Domain.Enums;

namespace AuctionService.Application.UseCases.Auctions.Create;

public class CreateAuctionUseCase : IUseCase<CreateAuctionRequest, CreateAuctionResponse>
{
    private readonly IAuctionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuctionUseCase(IAuctionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<CreateAuctionResponse> Execute(CreateAuctionRequest request)
    {
        await _unitOfWork.BeginTransactionAsync();
        await _repository.AddAsync(Request(request));
        await _unitOfWork.CommitAsync();
        
        return new CreateAuctionResponse();
    }

    private Auction Request(CreateAuctionRequest request)
    {
        return new Auction(
            Guid.NewGuid(),
            request.ReservePrice,
            RequestItem(request),
            null,
                null,
            null,
            null,
            Status.Live,
            request.AuctionEnd);
    }

    private Item RequestItem(CreateAuctionRequest request)
    {
        return new Item(
            Guid.NewGuid(),
            request.Make,
            request.Model,
            request.Year,
            request.Color,
            request.Mileage,
            request.ImageUrl);
    }
}
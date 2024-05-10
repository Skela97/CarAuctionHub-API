using AuctionService.Application.Contracts;
using AuctionService.Application.Contracts.Publishers;
using AuctionService.Application.Exceptions;
using AuctionService.Common.Interfaces;
using AuctionService.Domain;

namespace AuctionService.Application.UseCases.Auctions.Update;

public class UpdateAuctionUseCase : IUseCase<UpdateAuctionRequest, UpdateAuctionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuctionRepository _repository;
    private readonly IAuctionPublisher _publisher;

    public UpdateAuctionUseCase(
        IUnitOfWork unitOfWork, 
        IAuctionRepository repository,
        IAuctionPublisher publisher
        )
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _publisher = publisher;
    }

    public async Task<UpdateAuctionResponse> ExecuteAsync(UpdateAuctionRequest request)
    {
        Auction? auction = await _repository.GetByIdAsync(request.Id!.Value);
        if (auction == null) throw new AuctionNotFoundException();

        ValidateSeller(auction, request);

        await _unitOfWork.BeginTransactionAsync();
        auction.Update(request.Make, request.Model, request.Year, request.Color, request.Mileage);
        await _publisher.PublishUpdatedAsync(auction);

        await _unitOfWork.CommitAsync();

        return new UpdateAuctionResponse();
    }

    private void ValidateSeller(Auction auction, UpdateAuctionRequest request)
    {
        if (auction.Seller != request.Seller)
        {
            throw new AuctionChangeNotAuthorizedException("The requested seller is not allower to modify this auction.");
        }
    }
}
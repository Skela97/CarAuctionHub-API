using AuctionService.Application.Contracts;
using AuctionService.Application.Exceptions;
using AuctionService.Common.Interfaces;
using AuctionService.Domain;

namespace AuctionService.Application.UseCases.Auctions.Update;

public class UpdateAuctionUseCase : IUseCase<UpdateAuctionRequest, UpdateAuctionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuctionRepository _repository;

    public UpdateAuctionUseCase(IUnitOfWork unitOfWork, IAuctionRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<UpdateAuctionResponse> Execute(UpdateAuctionRequest request)
    {
        Auction auction = await _repository.GetByIdAsync(request.Id!.Value);
        if (auction == null) throw new AuctionNotFoundException();
        
        await _unitOfWork.BeginTransactionAsync();
        auction.Update(request.Make,request.Model,request.Year,request.Color, request.Mileage);
        await _unitOfWork.CommitAsync();
        
        return new UpdateAuctionResponse();
    }
}
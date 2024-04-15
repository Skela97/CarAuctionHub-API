using AuctionService.Application.Contracts;
using AuctionService.Application.Exceptions;
using AuctionService.Common.Interfaces;
using AuctionService.Domain;

namespace AuctionService.Application.UseCases.Auctions.Delete;

public class DeleteAuctionUseCase : IUseCase<DeleteAuctionRequest, DeleteAuctionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuctionRepository _repository;

    public DeleteAuctionUseCase(IUnitOfWork unitOfWork, IAuctionRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task<DeleteAuctionResponse> Execute(DeleteAuctionRequest request)
    {
        Auction auction = await _repository.GetByIdAsync(request.Id);
        if (auction == null) throw new AuctionNotFoundException(); 
        
        await _unitOfWork.BeginTransactionAsync();
        await _repository.DeleteAsync(auction);
        await _unitOfWork.CommitAsync();

        return new DeleteAuctionResponse();
    }
}
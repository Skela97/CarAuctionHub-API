using AuctionService.Application.Contracts;
using AuctionService.Application.Contracts.Publishers;
using AuctionService.Application.Exceptions;
using AuctionService.Common.Interfaces;
using AuctionService.Domain;

namespace AuctionService.Application.UseCases.Auctions.Delete;

public class DeleteAuctionUseCase : IUseCase<DeleteAuctionRequest, DeleteAuctionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuctionRepository _repository;
    private readonly IAuctionPublisher _publisher;

    public DeleteAuctionUseCase(
        IUnitOfWork unitOfWork, 
        IAuctionRepository repository,
        IAuctionPublisher publisher)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _publisher = publisher;
    }
    
    public async Task<DeleteAuctionResponse> ExecuteAsync(DeleteAuctionRequest request)
    {
        Auction auction = await _repository.GetByIdAsync(request.Id);
        if (auction == null) throw new AuctionNotFoundException(); 
        
        await _unitOfWork.BeginTransactionAsync();
        await _repository.DeleteAsync(auction);
        await _publisher.PublishDeletedAsync(auction);
        await _unitOfWork.CommitAsync();

        return new DeleteAuctionResponse();
    }
}
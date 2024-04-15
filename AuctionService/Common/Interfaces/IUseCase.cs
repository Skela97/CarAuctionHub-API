namespace AuctionService.Common.Interfaces;

// ReSharper disable once TypeParameterCanBeVariant
public interface IUseCase<TRequest, TResponse>
{
    public Task<TResponse> Execute(TRequest request);
}
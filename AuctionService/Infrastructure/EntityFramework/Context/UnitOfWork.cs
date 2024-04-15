using AuctionService.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuctionService.Infrastructure.EntityFramework.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuctionDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync() ?? throw new ArgumentException();
    }

    public async Task CommitAsync()
    {
        if (_transaction == null) throw new Exception("Please begin the transaction before commiting it.");
        
        try
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    private async Task RollbackAsync()
    {
        if (_transaction == null) throw new Exception("Please begin the transaction before commiting it.");
        
        await _transaction.RollbackAsync();
    }
}
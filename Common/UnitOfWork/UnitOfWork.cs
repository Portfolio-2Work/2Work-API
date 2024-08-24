using _2Work_API.Entities;
using _2Work_API.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;

namespace _2Work_API.Common.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        public async Task<Exception?> Commit(CancellationToken ct = default)
        {
            Exception? exception = null;
            try
            {
                await _context.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                exception = ex;
                await Rollback();
            }

            return exception;
        }

        public async Task BeginTransaction(CancellationToken ct = default)
        {
            _transaction ??= await _context.Database.BeginTransactionAsync(ct);
        }

        public async Task Rollback(CancellationToken ct = default)
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(ct);
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }

            await _context.DisposeAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}

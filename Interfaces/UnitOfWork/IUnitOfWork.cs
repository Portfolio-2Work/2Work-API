namespace _2Work_API.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Exception?> Commit(CancellationToken ct = default);
        Task Rollback(CancellationToken ct = default);
        Task BeginTransaction(CancellationToken ct = default);
    }
}

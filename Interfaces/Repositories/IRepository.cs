namespace _2Work_API.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(Guid id, CancellationToken ct = default);
        Task<List<TEntity>> GetAll(CancellationToken ct = default);
        Task<TEntity?> Add(TEntity entity, CancellationToken ct = default);
        Task<bool> Update(TEntity entity, CancellationToken ct = default);
    }
}

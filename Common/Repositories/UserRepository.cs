using _2Work_API.Entities;
using _2Work_API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _2Work_API.Common.Repositories
{
    public class UserRepository(DBContext dbContext) : IUserRepository
    {
        public async Task<TB_User?> Add(TB_User entity, CancellationToken ct = default)
        {
            await dbContext.TB_User.AddAsync(entity, ct);

            //dbContext.Entry(entity).State = EntityState.Added;

            //int saved = await dbContext.SaveChangesAsync(ct);

            //if (saved == 0)
            //{
            //    return null;
            //}

            return entity;
        }

        public async Task<TB_User?> Get(Guid id, CancellationToken ct = default)
        {
            return await (from a in dbContext.TB_User where a.ID == id select a).FirstOrDefaultAsync(ct);
        }

        public async Task<List<TB_User>> GetAll(CancellationToken ct = default)
        {
            return await (from a in dbContext.TB_User select a).ToListAsync(ct);
        }

        public async Task<bool> Update(TB_User entity, CancellationToken ct = default)
        {
            dbContext.TB_User.Update(entity);

            dbContext.Entry(entity).State = EntityState.Modified;

            int saved = await dbContext.SaveChangesAsync(ct);

            return saved != 0;
        }
    }
}

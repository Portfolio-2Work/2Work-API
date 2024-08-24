using _2Work_API.Entities;
using _2Work_API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _2Work_API.Common.Repositories
{
    public class EmpresaRepository(DBContext dbContext) : IEmpresaRepository
    {
        public async Task<TB_Empresa?> Add(TB_Empresa entity, CancellationToken ct = default)
        {
            await dbContext.TB_Empresa.AddAsync(entity, ct);

            dbContext.Entry(entity).State = EntityState.Added;

            int saved = await dbContext.SaveChangesAsync(ct);

            if (saved == 0)
            {
                return null;
            }

            return entity;
        }

        public async Task<TB_Empresa?> Get(Guid id, CancellationToken ct = default)
        {
            return await (from a in dbContext.TB_Empresa where a.ID == id select a).FirstOrDefaultAsync(ct);
        }

        public async Task<List<TB_Empresa>> GetAll(CancellationToken ct = default)
        {
            return await (from a in dbContext.TB_Empresa select a).ToListAsync(ct);
        }

        public async Task<bool> Update(TB_Empresa entity, CancellationToken ct = default)
        {
            dbContext.TB_Empresa.Update(entity);

            dbContext.Entry(entity).State = EntityState.Modified;

            int saved = await dbContext.SaveChangesAsync(ct);
            return saved != 0;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace _2Work_API.Entities;

public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
{
    public DbSet<TB_User> TB_User { get; set; }
    public DbSet<TB_Empresa> TB_Empresa { get; set; }
    public DbSet<TB_User_x_Empresa> TB_User_x_Empresa { get; set; }
}

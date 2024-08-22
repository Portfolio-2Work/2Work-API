using Microsoft.EntityFrameworkCore;

namespace _2Work_API.Entities;

public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
{
    public DbSet<Users> Users { get; set; }
}

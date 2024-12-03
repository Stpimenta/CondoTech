using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;

namespace WebApplication1.Infrastructure.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    { }

    public DbSet<CondominiumModel> Condominiums { get; set; }
}
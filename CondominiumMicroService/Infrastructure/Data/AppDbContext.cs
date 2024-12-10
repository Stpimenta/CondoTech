using CondominiumMicroService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CondominiumMicroService.Infrastructure.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    { }

    public DbSet<CondominiumModel> Condominiums { get; set; }
}
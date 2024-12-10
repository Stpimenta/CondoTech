using Microsoft.EntityFrameworkCore;
using WorkerMicroService.Domain.Models;

namespace WorkerMicroService.Infrastructure.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    { }

    public DbSet<WorkerModel> Worker { get; set; }
}
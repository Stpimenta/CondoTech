using MicroServiceWorkOrder.Domain;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceWorkOrder.Infrastructure.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    { }

    public DbSet<WorkOrderModel> WorkOrder { get; set; }
}
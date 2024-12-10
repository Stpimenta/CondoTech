using MicroServiceWorkOrder.Domain;
using MicroServiceWorkOrder.Domain.Enums;
using MicroServiceWorkOrder.Infrastructure.Data;

namespace MicroServiceWorkOrder.Infrastructure.Seed;

public class DbSeed
{
    private readonly AppDbContext _dbContext;
    
    public DbSeed(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CondominiumSeeder()
    {
        if (!_dbContext.WorkOrder.Any())
        {
             _dbContext.WorkOrder.AddRange(
                 new WorkOrderModel
                 {
                     Id = 1,
                     IdCondominium = 1,
                     IdWorker = 1,
                     Descricao = "Reparo na iluminação externa",
                     Satus = WorkOrderStatusEnum.Open
                 },
                 new WorkOrderModel
                 {
                     Id = 2,
                     IdCondominium = 2,
                     IdWorker = 2,
                     Descricao = "Manutenção da piscina",
                     Satus = WorkOrderStatusEnum.InProgress
                 },
                 new WorkOrderModel
                 {
                     Id = 3,
                     IdCondominium = 3,
                     IdWorker = 3,
                     Descricao = "Troca de equipamentos da academia",
                     Satus = WorkOrderStatusEnum.Closed
                 },
                 new WorkOrderModel
                 {
                     Id = 4,
                     IdCondominium = 4,
                     IdWorker = 4,
                     Descricao = "Pintura das áreas comuns",
                     Satus = WorkOrderStatusEnum.Open
                 },
                 new WorkOrderModel
                 {
                     Id = 5,
                     IdCondominium = 1,
                     IdWorker = 2,
                     Descricao = "Revisão do sistema de segurança",
                     Satus = WorkOrderStatusEnum.Cancelled
                 }
            );
            _dbContext.SaveChanges();
        }
    }
}
using MicroServiceWorkOrder.Domain;

namespace MicroServiceWorkOrder.Infrastructure.Repository.Interfaces;

public interface IWorkOrderRepository
{
   
   public Task<List<WorkOrderModel>> GetAllAsync();
   public Task<WorkOrderModel> GetByIdAsync(int id);
   public Task<int> AddAsync(WorkOrderModel condominium);
   public Task UpdateAsync(int id, WorkOrderModel condominium);
   public Task<int> DeleteAsync(int id);
   
}
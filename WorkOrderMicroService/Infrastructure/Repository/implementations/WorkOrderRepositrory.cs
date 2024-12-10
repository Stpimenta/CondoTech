using MicroServiceWorkOrder.Domain;
using MicroServiceWorkOrder.Infrastructure.Data;
using MicroServiceWorkOrder.Infrastructure.Repository.Interfaces;
using MicroServiceWorkOrder.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceWorkOrder.Infrastructure.Repository;

public class WorkOrderRepositrory : IWorkOrderRepository
{
    private readonly AppDbContext _dbContext;

    public WorkOrderRepositrory(AppDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }
    
    public async Task<List<WorkOrderModel>> GetAllAsync()
    {
        return await _dbContext.WorkOrder.ToListAsync();
    }

    public async Task<WorkOrderModel> GetByIdAsync(int id)
    {
      
        var workOrder = await _dbContext.WorkOrder.FindAsync(id);

        if (workOrder is null)
        {
            throw new NotFoundException($"WorkOrder with id:{id} not found", DateTime.Now);
        }

        return  workOrder;
    }

    public async Task<int> AddAsync(WorkOrderModel workOrderModel)
    {
        await _dbContext.WorkOrder.AddAsync(workOrderModel);
        await _dbContext.SaveChangesAsync();
        return workOrderModel.Id;
    }

    public async Task UpdateAsync(int id, WorkOrderModel updatedWorkOrderModel)
    {
        var  workOrder =  await GetByIdAsync(id);

        // update properties 
        workOrder.Descricao = updatedWorkOrderModel.Descricao;
        workOrder.IdCondominium = updatedWorkOrderModel.IdCondominium;
        workOrder.IdWorker = updatedWorkOrderModel.IdWorker;
        workOrder.Satus = updatedWorkOrderModel.Satus;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var workOrderProvider = await GetByIdAsync(id);

        _dbContext.WorkOrder.Remove(workOrderProvider);

        await _dbContext.SaveChangesAsync();

        return workOrderProvider.Id;
    }
}
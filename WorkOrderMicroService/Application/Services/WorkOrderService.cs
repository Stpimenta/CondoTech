using MicroServiceWorkOrder.Application.ClientServices.Interfaces;
using MicroServiceWorkOrder.Application.Dtos;
using MicroServiceWorkOrder.Domain;
using MicroServiceWorkOrder.Infrastructure.Repository.Interfaces;

namespace MicroServiceWorkOrder.Application.Services;

public class WorkOrderService
{
    private readonly IWorkOrderRepository _workOrderRepository;
    private readonly IWorkerClientService _workerClientService;
    private readonly ICondominiumClientService _condominiumClientService;
    
    public WorkOrderService(IWorkOrderRepository workOrderRepository, ICondominiumClientService condominiumClientService, IWorkerClientService workerClientService)
    {
        _workOrderRepository = workOrderRepository;
        _workerClientService = workerClientService;
        _condominiumClientService = condominiumClientService;
    }

    public async Task<List<WorkOrderModel>> GetAllAsync()
    {
        return await _workOrderRepository.GetAllAsync();
    }
    
    public async Task<WorkOrderModel> GetById (int id)
    {
        var condominium = await _workOrderRepository.GetByIdAsync(id);
        return condominium;
    }
    
    public async Task<int> Addasync( WorkOrderDto.CreateAndGetWorkOrder workerOrderDto)
    {
        /* The service check throws an error if the object doesn't exist, and the error middleware handles it. No further logic is needed for the response. */
        await _workerClientService.CheckExistWorkerAsync(workerOrderDto.IdWorker);
        await _condominiumClientService.CheckExistCondominiumAsync(workerOrderDto.IdCondominium);
        
        WorkOrderModel workOrderModel = new WorkOrderModel
        {
            Descricao   = workerOrderDto.Descricao,
            Satus =  workerOrderDto.Satus,
            IdWorker = workerOrderDto.IdWorker,
            IdCondominium = workerOrderDto.IdCondominium
        };
        
        return await _workOrderRepository.AddAsync(workOrderModel);
    }

    public async Task UpdateAsync(int id, WorkOrderDto.CreateAndGetWorkOrder workerOrderDto)
    {
        WorkOrderModel workOrderModel = new WorkOrderModel
        {
            Descricao   = workerOrderDto.Descricao,
            Satus =  workerOrderDto.Satus,
            IdWorker = workerOrderDto.IdWorker,
            IdCondominium = workerOrderDto.IdCondominium
            
        };
        await _workOrderRepository.UpdateAsync(id, workOrderModel);
    }
    
    public async Task DeleteById (int id)
    {
        await _workOrderRepository.DeleteAsync(id);
    }
}
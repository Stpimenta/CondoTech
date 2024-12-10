using WorkerMicroService.Application.Dtos;
using WorkerMicroService.Domain.Models;
using WorkerMicroService.Infrastructure.Repository.Interfaces;

namespace WorkerMicroService.Application.Services;

public class WorkerService
{
    private readonly IWorkerRepository _workerRepository;
    
    public WorkerService(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<List<WorkerModel>> GetAllAsync()
    {
        return await _workerRepository.GetAllAsync();
    }
    
    public async Task<WorkerModel> GetById (int id)
    {
        var condominium = await _workerRepository.GetByIdAsync(id);
        return condominium;
    }
    
    public async Task<int> Addasync( WorkerDtos.CreateAndGetWorker worker)
    {
        
        WorkerModel workerModel = new WorkerModel
        {
            Name = worker.Name,
            Gmail = worker.Gmail,  
            Senha = worker.Senha   
        };
       
        return await _workerRepository.AddAsync(workerModel);
    }

    public async Task UpdateAsync(int id, WorkerDtos.CreateAndGetWorker worker)
    {
        WorkerModel workerModel = new WorkerModel
        {
           Name = worker.Name,
           Gmail = worker.Gmail,
           Senha = worker.Senha
            
        };
        await _workerRepository.UpdateAsync(id, workerModel);
    }
    
    public async Task DeleteById (int id)
    {
        await _workerRepository.DeleteAsync(id);
    }
    
    
}
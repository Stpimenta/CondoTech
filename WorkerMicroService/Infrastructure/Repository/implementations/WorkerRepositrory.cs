using Microsoft.EntityFrameworkCore;
using WorkerMicroService.Domain.Models;
using WorkerMicroService.Infrastructure.Data;
using WorkerMicroService.Infrastructure.Repository.Interfaces;
using WorkerMicroService.Shared.Exceptions;

namespace WorkerMicroService.Infrastructure.Repository.implementations;

public class WorkerRepositrory : IWorkerRepository
{
    private readonly AppDbContext _dbContext;

    public WorkerRepositrory(AppDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }
    
    public async Task<List<WorkerModel>> GetAllAsync()
    {
        return await _dbContext.Worker.ToListAsync();
    }

    public async Task<WorkerModel> GetByIdAsync(int id)
    {
      
        var provider = await _dbContext.Worker.FindAsync(id);

        if (provider is null)
        {
            throw new NotFoundException($"worker with id:{id} not found", DateTime.Now);
        }

        return  provider;
    }

    public async Task<int> AddAsync(WorkerModel workerModel)
    {
        await _dbContext.Worker.AddAsync(workerModel);
        await _dbContext.SaveChangesAsync();
        return workerModel.Id;
    }

    public async Task UpdateAsync(int id, WorkerModel updatedWorkerModel)
    {
        var  provider =  await GetByIdAsync(id);

        // update properties 
        provider.Name = updatedWorkerModel.Name;
        provider.Gmail = updatedWorkerModel.Gmail;
        provider.Senha = updatedWorkerModel.Senha;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var existingProvider = await GetByIdAsync(id);

        _dbContext.Worker.Remove(existingProvider);

        await _dbContext.SaveChangesAsync();

        return existingProvider.Id;
    }
}
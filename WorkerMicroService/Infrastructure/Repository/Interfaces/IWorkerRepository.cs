using WorkerMicroService.Domain.Models;

namespace WorkerMicroService.Infrastructure.Repository.Interfaces;

public interface IWorkerRepository
{
   
   public Task<List<WorkerModel>> GetAllAsync();
   public Task<WorkerModel> GetByIdAsync(int id);
   public Task<int> AddAsync(WorkerModel condominium);
   public Task UpdateAsync(int id, WorkerModel condominium);
   public Task<int> DeleteAsync(int id);
   
}
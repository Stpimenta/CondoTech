using CondominiumMicroService.Domain;

namespace CondominiumMicroService.Infrastructure.Repository.Interfaces;

public interface ICondominiumRepositrory
{
   
   public Task<List<CondominiumModel>> GetAllAsync();
   public Task<CondominiumModel> GetByIdAsync(int id);
   public Task<int> AddAsync(CondominiumModel condominium);
   public Task UpdateAsync(int id, CondominiumModel condominium);
   public Task<int> DeleteAsync(int id);
   
}
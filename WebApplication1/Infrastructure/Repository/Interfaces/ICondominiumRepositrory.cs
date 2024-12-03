using WebApplication1.Domain;

namespace WebApplication1.Infrastructure.Repository.Interfaces;

public interface ICondominiumRepositrory
{
   
   public Task<List<CondominiumModel>> GetAllAsync();
   public Task<int> AddAsync(CondominiumModel condominium);
}
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Infrastructure.Data;
using WebApplication1.Infrastructure.Repository.Interfaces;

namespace WebApplication1.Infrastructure.Repository;

public class CondominiumRepositrory : ICondominiumRepositrory
{
    private readonly AppDbContext _dbContext;

    public CondominiumRepositrory(AppDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }
    
    public async Task<List<CondominiumModel>> GetAllAsync()
    {
        return await _dbContext.Condominiums.ToListAsync();
    }

    public async Task<int> AddAsync(CondominiumModel condominium)
    {
        await _dbContext.Condominiums.AddAsync(condominium);
        await _dbContext.SaveChangesAsync();
        return condominium.Id;
    }
    
}
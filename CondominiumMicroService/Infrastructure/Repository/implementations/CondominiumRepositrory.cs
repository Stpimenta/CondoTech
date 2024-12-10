using CondominiumMicroService.Domain;
using CondominiumMicroService.Infrastructure.Data;
using CondominiumMicroService.Infrastructure.Repository.Interfaces;
using CondominiumMicroService.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CondominiumMicroService.Infrastructure.Repository;

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

    public async Task<CondominiumModel> GetByIdAsync(int id)
    {
      
        var condominium = await _dbContext.Condominiums.FindAsync(id);

        if (condominium is null)
        {
            throw new NotFoundException($"condominium with id:{id} not found", DateTime.Now);
        }

        return condominium;
    }

    public async Task<int> AddAsync(CondominiumModel condominium)
    {
        await _dbContext.Condominiums.AddAsync(condominium);
        await _dbContext.SaveChangesAsync();
        return condominium.Id;
    }

    public async Task UpdateAsync(int id, CondominiumModel updatedCondominium)
    {
        var existingCondominium =  await GetByIdAsync(id);

        // update properties 
        existingCondominium.Name = updatedCondominium.Name;
        existingCondominium.Address = updatedCondominium.Address;
        existingCondominium.Cep = updatedCondominium.Cep;
        existingCondominium.NumberOfFloors = updatedCondominium.NumberOfFloors;
        existingCondominium.ApartmentsPerFloor = updatedCondominium.ApartmentsPerFloor;
        existingCondominium.YearOfConstruction = updatedCondominium.YearOfConstruction;
        existingCondominium.HasElevator = updatedCondominium.HasElevator;

        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var existingCondominium = await GetByIdAsync(id);

        _dbContext.Condominiums.Remove(existingCondominium);

        await _dbContext.SaveChangesAsync();

        return existingCondominium.Id;
    }
}
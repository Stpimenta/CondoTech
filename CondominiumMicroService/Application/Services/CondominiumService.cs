using CondominiumMicroService.Application.Dtos;
using CondominiumMicroService.Domain;
using CondominiumMicroService.Infrastructure.Repository.Interfaces;

namespace CondominiumMicroService.Application.Services;

public class CondominiumService
{
    private readonly ICondominiumRepositrory _condominiumRepositrory;
    
    public CondominiumService(ICondominiumRepositrory condominiumRepositrory)
    {
        _condominiumRepositrory = condominiumRepositrory;
    }

    public async Task<List<CondominiumModel>> GetAllAsync()
    {
        return await _condominiumRepositrory.GetAllAsync();
    }
    
    public async Task<CondominiumModel> GetById (int id)
    {
        var condominium = await _condominiumRepositrory.GetByIdAsync(id);
        return condominium;
    }
    
    public async Task<int> Addasync( CondominiumDtos.CreateAndGetCondominiumDto condominium)
    {
        CondominiumModel condominiumModel = new CondominiumModel
        {
            Name = condominium.Name,
            Address = condominium.Address,
            Cep = condominium.Cep,
            YearOfConstruction = condominium.YearOfConstruction,
            NumberOfFloors = condominium.NumberOfFloors,
            ApartmentsPerFloor = condominium.ApartmentsPerFloor,
            HasElevator = condominium.HasElevator
            
        };
       
        return await _condominiumRepositrory.AddAsync(condominiumModel);
    }

    public async Task UpdateAsync(int id, CondominiumDtos.CreateAndGetCondominiumDto condominium)
    {
        CondominiumModel condominiumModel = new CondominiumModel
        {
            Name = condominium.Name,
            Address = condominium.Address,
            Cep = condominium.Cep,
            YearOfConstruction = condominium.YearOfConstruction,
            NumberOfFloors = condominium.NumberOfFloors,
            ApartmentsPerFloor = condominium.ApartmentsPerFloor,
            HasElevator = condominium.HasElevator
            
        };
        await _condominiumRepositrory.UpdateAsync(id, condominiumModel);
    }
    
    public async Task DeleteById (int id)
    {
        await _condominiumRepositrory.DeleteAsync(id);
    }
    
    
}
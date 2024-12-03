using WebApplication1.Application.Dtos;
using WebApplication1.Domain;
using WebApplication1.Infrastructure.Repository.Interfaces;

namespace WebApplication1.Services;

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
    
    public async Task<int> Addasync( CondominiumDtos.CreateCondominiumDto condominium)
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
}
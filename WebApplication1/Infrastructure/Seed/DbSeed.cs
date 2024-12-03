using WebApplication1.Domain;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Seed;

public class DbSeed
{
    private readonly AppDbContext _dbContext;
    
    public DbSeed(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CondominiumSeeder()
    {
        if (!_dbContext.Condominiums.Any())
        {
             _dbContext.Condominiums.AddRange(
                new CondominiumModel
                {
                    Name = "Condomínio Parque das Flores",
                    Address = "Rua das Acácias, 123",
                    Cep = "12345-678",
                    NumberOfFloors = 10,
                    ApartmentsPerFloor = 4,
                    YearOfConstruction = new DateTime(2005, 6, 15),
                    HasElevator = true
                },
                new CondominiumModel
                {
                    Name = "Condomínio Bella Vista",
                    Address = "Avenida Rio de Janeiro, 456",
                    Cep = "98765-432",
                    NumberOfFloors = 6,
                    ApartmentsPerFloor = 2,
                    YearOfConstruction = new DateTime(2015, 11, 20),
                    HasElevator = false
                },
                new CondominiumModel
                {
                    Name = "Condomínio Sol Nascente",
                    Address = "Rua do Sol, 789",
                    Cep = "54321-098",
                    NumberOfFloors = 8,
                    ApartmentsPerFloor = 3,
                    YearOfConstruction = new DateTime(2010, 3, 10),
                    HasElevator = true
                },
                new CondominiumModel
                {
                    Name = "Condomínio Vista Alegre",
                    Address = "Rua do Lago, 101",
                    Cep = "11223-445",
                    NumberOfFloors = 12,
                    ApartmentsPerFloor = 5,
                    YearOfConstruction = new DateTime(2018, 8, 25),
                    HasElevator = true
                },
                new CondominiumModel
                {
                    Name = "Condomínio Jardim das Palmeiras",
                    Address = "Rua das Palmeiras, 202",
                    Cep = "22334-556",
                    NumberOfFloors = 4,
                    ApartmentsPerFloor = 6,
                    YearOfConstruction = new DateTime(2000, 12, 5),
                    HasElevator = false
                }
            );
            _dbContext.SaveChanges();
        }
    }
}
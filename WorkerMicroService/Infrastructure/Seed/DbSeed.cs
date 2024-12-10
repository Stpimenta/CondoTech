using WorkerMicroService.Domain.Models;
using WorkerMicroService.Infrastructure.Data;

namespace WorkerMicroService.Infrastructure.Seed;

public class DbSeed
{
    private readonly AppDbContext _dbContext;
    
    public DbSeed(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CondominiumSeeder()
    {
        if (!_dbContext.Worker.Any())
        {
             _dbContext.Worker.AddRange(
                 new WorkerModel
                 {
                     Name = "Condomínio Parque das Flores",
                     Gmail = "contato@parquedasflores.com.br",
                     Senha = "senha123"
                 },
                 new WorkerModel
                 {
                     Name = "Condomínio Bella Vista",
                     Gmail = "contato@bellavista.com.br",
                     Senha = "senha456"
                 },
                 new WorkerModel
                 {
                     Name = "Condomínio Sol Nascente",
                     Gmail = "contato@solnascente.com.br",
                     Senha = "senha789"
                 },
                 new WorkerModel
                 {
                     Name = "Condomínio Vista Alegre",
                     Gmail = "contato@vistaalegre.com.br",
                     Senha = "senha101"
                 },
                 new WorkerModel
                 {
                     Name = "Condomínio Jardim das Palmeiras",
                     Gmail = "contato@jardimdaspalmeiras.com.br",
                     Senha = "senha102"
                 }
            );
            _dbContext.SaveChanges();
        }
    }
}
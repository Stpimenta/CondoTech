namespace WorkerMicroService.Domain.Models;

public class WorkerModel
{
    public int Id { get; set; } // Unique ID 
    public string Name { get; set; }
    
    public string Gmail { get; set; }

    public string Senha { get; set; }

}
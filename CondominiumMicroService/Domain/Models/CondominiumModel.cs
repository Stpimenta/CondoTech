namespace CondominiumMicroService.Domain;

public class CondominiumModel
{
    public int Id { get; set; } // Unique ID 
    public string Name { get; set; }
    public string Address { get; set; } 
    public string Cep { get; set; } 
    public int NumberOfFloors { get; set; } 
    public int ApartmentsPerFloor { get; set; } 
    public DateTime YearOfConstruction { get; set; } 
    public bool HasElevator { get; set; } 

}
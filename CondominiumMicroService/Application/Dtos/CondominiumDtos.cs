using System.ComponentModel.DataAnnotations;

namespace CondominiumMicroService.Application.Dtos;

public class CondominiumDtos
{
    public class CreateAndGetCondominiumDto
    {   
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; } 
        
        [Required]
        public string Cep { get; set; } 
        
        [Required]
        public DateTime YearOfConstruction { get; set; } 
        
        [Range(1, int.MaxValue)]
        public int NumberOfFloors { get; set; } 
        
        [Range(1, int.MaxValue)]
        public int ApartmentsPerFloor { get; set; } 
        
        public bool HasElevator { get; set; } 
    }

   
}
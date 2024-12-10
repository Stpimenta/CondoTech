using System.ComponentModel.DataAnnotations;

namespace WorkerMicroService.Application.Dtos;

public class WorkerDtos
{
    public class CreateAndGetWorker
    {   
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Gmail { get; set; }
        
        [Required]
        public string Senha { get; set; }

    }

   
}
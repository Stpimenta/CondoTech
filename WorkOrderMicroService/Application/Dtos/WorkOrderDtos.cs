using System.ComponentModel.DataAnnotations;
using MicroServiceWorkOrder.Domain.Enums;

namespace MicroServiceWorkOrder.Application.Dtos;

public class WorkOrderDto
{
    public class CreateAndGetWorkOrder
    {   
        [Required]
        public int  IdCondominium{ get; set; } // Unique ID 
        
        [Required]
        public int IdWorker { get; set; } // Unique ID
        
        [Required]
        public string Descricao{ get; set; }
        
        [Required]
        public WorkOrderStatusEnum Satus { get; set; }

    }

   
}
using MicroServiceWorkOrder.Domain.Enums;

namespace MicroServiceWorkOrder.Domain;

public class WorkOrderModel
{
    public int Id { get; set; } // Unique ID 
    
    public int  IdCondominium{ get; set; } // Unique ID 
    
    public int IdWorker { get; set; } // Unique ID
    
    public string Descricao{ get; set; }

    public WorkOrderStatusEnum Satus { get; set; }

}
namespace MicroServiceWorkOrder.Application.ClientServices.Interfaces;

public interface IWorkerClientService
{
    public Task CheckExistWorkerAsync(int id);
    
}
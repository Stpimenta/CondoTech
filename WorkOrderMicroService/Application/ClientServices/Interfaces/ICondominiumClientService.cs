namespace MicroServiceWorkOrder.Application.ClientServices.Interfaces;

public interface ICondominiumClientService
{
    public Task CheckExistCondominiumAsync (int id);
}
using System.Net;
using System.Text.Json;
using MicroServiceWorkOrder.Application.ClientServices.Interfaces;
using MicroServiceWorkOrder.Shared.Exceptions;

namespace MicroServiceWorkOrder.Application.ClientServices.Implementation;


public class WorkerClientService:IWorkerClientService
{
    private readonly HttpClient _httpClient;

    public  WorkerClientService( HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CheckExistWorkerAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/Worker/{id}");
        
        if (response.StatusCode == HttpStatusCode.OK)
            return;

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var jsonObj = JsonDocument.Parse(responseData);
    
     
            if (jsonObj.RootElement.TryGetProperty("detail", out JsonElement detailProperty))
            {
                var errorMessage = detailProperty.GetString();
                throw new NotFoundException(errorMessage!, DateTime.Now);
            }
            
            throw new Exception("worker http response is not found but property 'detail' doesnt exist"); 
        }
        
        throw new Exception("Condominium Api did response");
           
    }
}
using System.Net;
using System.Text.Json;
using MicroServiceWorkOrder.Application.ClientServices.Interfaces;
using MicroServiceWorkOrder.Shared.Exceptions;

namespace MicroServiceWorkOrder.Application.ClientServices.Implementation;

public class CondominiumClientService: ICondominiumClientService
{
    HttpClient _httpClient;
    
    public CondominiumClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
    public  async Task CheckExistCondominiumAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/Condominium/{id}");
        
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
            
            throw new Exception("Condominium http response is not found but property 'detail' doesnt exist"); 
        }
        
        throw new Exception("Condominium Api did response");
    }
}
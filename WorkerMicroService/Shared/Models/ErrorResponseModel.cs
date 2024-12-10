namespace WorkerMicroService.Shared.Models;

public class ErrorResponseModel
{
    public string Title { get; set; }
    public int Status { get; set; }
    public string TraceId { get; set; }
    public string Detail { get; set; }
    
    public DateTime Date { get; set; }
}
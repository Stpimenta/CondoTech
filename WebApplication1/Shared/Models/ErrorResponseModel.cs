namespace WebApplication1.Shared.Models;

public class ErrorResponseModel
{
    public string Type { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string TraceId { get; set; }
    public string Detail { get; set; }
}
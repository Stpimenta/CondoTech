namespace MicroServiceWorkOrder.Shared.Exceptions;

public class NotFoundException : Exception
{
    public DateTime Date;
    public NotFoundException(string message, DateTime date) : base(message)
    {
        Date = date;
    }

   
}
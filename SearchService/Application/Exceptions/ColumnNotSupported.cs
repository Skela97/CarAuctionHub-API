namespace SearchService.Application.Exceptions;

public class ColumnNotSupportedException : Exception
{
    public ColumnNotSupportedException(string message) : base($"Column with the name '{message}' is not supported")
    {
    }
}

namespace SearchService.Exceptions;

public class IncorrectInitializationInputException : Exception
{
    public IncorrectInitializationInputException():base("Please re-check the format of JSON initialization input.") 
    {
    }
}

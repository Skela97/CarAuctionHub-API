namespace SearchService.Infrastructure.MassTransit.Exceptions
{
    public class MessageParsingFailedException : Exception
    {
        public MessageParsingFailedException() : base("Message could not be parsed")
        {
        }
    }
}

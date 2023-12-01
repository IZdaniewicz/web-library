namespace web_library.Shared;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string message)
        : base(message)
    {
    }
}
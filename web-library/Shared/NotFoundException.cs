namespace web_library.Shared;

public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}
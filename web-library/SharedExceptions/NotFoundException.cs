<<<<<<< HEAD:web-library/Shared/NotFoundException.cs
namespace web_library.Shared;
=======
namespace web_library.SharedExceptions;
>>>>>>> master:web-library/SharedExceptions/NotFoundException.cs

public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}
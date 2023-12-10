using System;

namespace web_library.SharedExceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string message)
        : base(message)
    {
    }
}
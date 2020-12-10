using System;

namespace Websad.Core.Exceptions
{
    public class TitleExistException: Exception
    {
        public TitleExistException() { }

        public TitleExistException(string message): base(message) { }
    }
}

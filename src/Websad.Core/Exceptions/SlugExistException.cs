using System;

namespace Websad.Core.Exceptions
{
    public class SlugExistException: Exception
    {
        public SlugExistException() { }

        public SlugExistException(string message): base(message) { }
    }
}

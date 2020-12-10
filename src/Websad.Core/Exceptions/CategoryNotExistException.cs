using System;

namespace Websad.Core.Exceptions
{
    public class CategoryNotExistException: Exception
    {
        public CategoryNotExistException(): base() { }

        public CategoryNotExistException(string message): base(message) { }
    }
}

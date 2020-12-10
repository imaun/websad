using System;

namespace Websad.Core.Exceptions
{
    public class PostNotFoundException: Exception
    {
        public PostNotFoundException() { }
        public PostNotFoundException(string message): base(message) {

        }
    }
}

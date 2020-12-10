using System;
using System.Collections.Generic;
using System.Text;

namespace Websad.Api.Models
{
    public class ApiModel<T> where T: class
    {
        public T Model { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}

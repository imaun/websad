using System;
using System.Collections.Generic;
using System.Text;
using Websad.Core.Contracts;

namespace Websad.Core.Utils
{
    public class DateService : IDateService
    {

        public DateTime Now() => DateTime.Now;

        public DateTime UtcNow() => DateTime.UtcNow;
    }
}

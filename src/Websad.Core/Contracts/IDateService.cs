using System;

namespace Websad.Core.Contracts
{
    public interface IDateService
    {
        DateTime UtcNow();
        DateTime Now();
    }
}

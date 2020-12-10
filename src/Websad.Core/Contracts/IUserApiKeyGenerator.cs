using Websad.Core.Models;

namespace Websad.Core.Contracts
{
    public interface IUserApiKeyGenerator
    {
        string GetNewApiKey();
        string GenerateApiKey(User user);
    }

}

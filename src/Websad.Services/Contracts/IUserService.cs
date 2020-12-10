using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Websad.Services.Data;

namespace Websad.Services.Contracts
{
    public interface IUserService {
        Task<UserApiLoginData> ApiLoginAsync(string apiKey);
    }
}

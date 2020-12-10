using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Websad.Core.Contracts;
using Websad.Core.Extensions;
using Websad.Services.Contracts;
using Websad.Services.Data;

namespace Websad.Services
{
    public class UserService: IUserService
    {
        private readonly IWebsadContext _db;
        //private DbSet<User> _dbSet;

        public UserService(IWebsadContext db) {
            db.CheckArgumentIsNull();
            _db = db;

            //_dbSet = _db.Set<User>();
        }

        public async Task<UserApiLoginData> ApiLoginAsync(string apiKey) {
            var user = await _db.Users
                .FirstOrDefaultAsync(_ => _.ApiKey == apiKey);
            if(user == null) 
                return new UserApiLoginData {
                    ApiKey = apiKey, 
                    Failed = true
                };
            
            var result = user.Adapt<UserApiLoginData>();

            return await Task.FromResult(result);
        }
    }
}

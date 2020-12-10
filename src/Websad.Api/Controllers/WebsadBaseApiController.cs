using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Websad.Core.Extensions;
using Websad.Services.Contracts;
using Websad.Services.Data;

namespace Websad.Api.Controllers
{
    public class WebsadBaseApiController: Controller {

        protected readonly IUserService _userService;

        public WebsadBaseApiController(IUserService userService) {
            userService.CheckArgumentIsNull();
            _userService = userService;
        }

        [NonAction]
        public async Task<UserApiLoginData> LoginAsync(string apiKey) {
            return await _userService.ApiLoginAsync(apiKey);
        }


    }
}

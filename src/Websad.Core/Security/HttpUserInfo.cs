using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Websad.Core.Extensions;

namespace Websad.Core.Security
{
    public class HttpUserInfo {
        private readonly IHttpContextAccessor _httpContext;

        public HttpUserInfo(IHttpContextAccessor httpContext) {
            httpContext.CheckArgumentIsNull(nameof(httpContext));
            _httpContext = httpContext;
        }

        private ClaimsPrincipal userPrincipal =>
            _httpContext.HttpContext.User;

        public int UserId =>
            int.Parse(userPrincipal?
                .FindFirst(ClaimTypes.NameIdentifier).Value!);

        public string UserName =>
            userPrincipal?
                .FindFirst(ClaimTypes.Name).Value;

        public string UserTitle =>
            userPrincipal?
                .FindFirst(WebsadClaimTypes.UserTitle).Value;

    }
}

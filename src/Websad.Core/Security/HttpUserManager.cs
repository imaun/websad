using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Websad.Core.Security
{
    public class HttpUserManager
    {

        private const string AuthenticationScheme = "Cookies";

        public async void SignInAsync(HttpContext context, UserPrincipalData model, bool isPresist = false) {
            ClaimsIdentity identity = new ClaimsIdentity(GetUserClaims(model),
                CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await context.SignInAsync(AuthenticationScheme, principal);
        }

        public async void SignOutAsync(HttpContext httpContext) {
            await httpContext.SignOutAsync(AuthenticationScheme);
        }

        private IEnumerable<Claim> GetUserClaims(UserPrincipalData user) =>
            new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Title),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("ApiKey", user.ApiKey),
                new Claim(ClaimTypes.Name, user.Username)
            };
        
    }
}

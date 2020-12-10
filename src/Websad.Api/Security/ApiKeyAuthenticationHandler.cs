using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Websad.Core.Extensions;
using Websad.Core.Security;
using Websad.Services.Contracts;

namespace Websad.Api.Security
{
    public class ApiKeyAuthenticationHandler: 
        AuthenticationHandler<ApiKeyAuthenticationOptions> 
    {
        private const string APIKEY_HEADER = "X-Api-Key";
        private const string ProblemDetailsContentType = "application/problem+json";
        private readonly IUserService _userService;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IUserService userService) : base(options, logger, encoder, clock) 
        {
            userService.CheckArgumentIsNull(nameof(userService));
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
            if(!Request.Headers.TryGetValue(APIKEY_HEADER, out var apiKeyHeaderValues)) {
                return AuthenticateResult.NoResult();
            }

            var apiKey = apiKeyHeaderValues.FirstOrDefault();

            if(apiKey.Length == 0 || string.IsNullOrWhiteSpace(apiKey)) {
                return AuthenticateResult.NoResult();
            }

            var loginResult = await _userService.ApiLoginAsync(apiKey);
            if(loginResult.Failed) {
                return AuthenticateResult.Fail("Invalid API Key.");
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, loginResult.Username),
                new Claim(WebsadClaimTypes.UserTitle, loginResult.Title),
                new Claim(ClaimTypes.NameIdentifier, loginResult.Id.ToString()),
                new Claim(WebsadClaimTypes.ApiKey, loginResult.ApiKey)
            };

            var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
            var identities = new List<ClaimsIdentity> { identity };
            var principal = new ClaimsPrincipal(identities);
            var ticket = new AuthenticationTicket(principal, Options.Scheme);

            return AuthenticateResult.Success(ticket);
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties) {
            Response.StatusCode = 401;
            Response.ContentType = ProblemDetailsContentType;
            var problemDetails = new UnauthorizedProblemDetails();

            await Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties) {
            Response.StatusCode = 403;
            Response.ContentType = ProblemDetailsContentType;
            var problemDetails = new ForbiddenProblemDetails();

            await Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }
}

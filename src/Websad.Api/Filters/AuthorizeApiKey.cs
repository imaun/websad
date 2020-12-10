using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Websad.Core.Extensions;
using Websad.Services.Contracts;

namespace Websad.Api.Filters
{
    //public class AuthorizeApiKey: AuthorizeAttribute, IAuthorizationFilter {
    //    public const string APIKEY_HEADER = "apikey";

    //    public void OnAuthorization(AuthorizationFilterContext context) {
    //        //var userService = context.HttpContext
    //        //    .RequestServices.GetService<IUserService>();
    //        //userService.CheckReferenceIsNull(nameof(userService));
    //        //if(context.HttpContext.Request.Headers[APIKEY_HEADER].Any()) {
    //        //    var apiKey = context.HttpContext
    //        //        .Request.Headers[APIKEY_HEADER][0];
    //        //    var loginResult = userService.ApiLoginAsync(apiKey).Result;
    //        //    if(!loginResult.Failed) {
    //        //        return;
    //        //    }
    //        //}

    //        //context.Result = new UnauthorizedResult();
            
            
    //    }
    //}

}

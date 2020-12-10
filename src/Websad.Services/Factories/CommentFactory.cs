using System;
using Mapster;
using Microsoft.AspNetCore.Http;
using Websad.Core.Contracts;
using Websad.Core.Extensions;
using Websad.Core.Models;
using Websad.Services.Data;

namespace Websad.Services.Factories
{
    public interface ICommentFactory
    {
        Comment Make(CommentCreateDto model);
    }

    public class CommentFactory : ICommentFactory
    {
        private readonly IDateService _dateService;
        private readonly IHttpContextAccessor _httpContext;


        public CommentFactory(IDateService dateService,
            IHttpContextAccessor httpContext) {

            dateService.CheckArgumentIsNull();
            _dateService = dateService;
            
            httpContext.CheckArgumentIsNull();
            _httpContext = httpContext;


        }

        public Comment Make(CommentCreateDto model) {
            model.CheckArgumentIsNull();
            var result = model.Adapt<Comment>();
            result.CreateDate = _dateService.UtcNow();
            result.SessionId = _httpContext.HttpContext
                .Session.Id;
            result.UserAgent = _httpContext.HttpContext
                .Request.Headers["User-Agent"][0];
            result.Ip = _httpContext.HttpContext
                .Connection.RemoteIpAddress?.ToString();
            //result.Url = _httpContext.HttpContext
            //    .Request.HttpContext.GetAbsoluteUrl();
            try {
                result.Url = _httpContext.HttpContext.GetAbsoluteUrl();
            }
            catch  { }
            
            return result;
        }
    }
}

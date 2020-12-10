using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Websad.Core.Extensions
{
    public static class Extensions {

        /// <summary>
        /// Checks if the argument is null.
        /// </summary>
        public static void CheckArgumentIsNull(this object o, string name = "") {
            if (string.IsNullOrWhiteSpace(name))
                name = nameof(o);
            if (o == null)
                throw new ArgumentNullException(name);
        }

        public static void CheckReferenceIsNull(this object o, string name = "") {
            if (string.IsNullOrWhiteSpace(name))
                name = nameof(o);
            if (o == null)
                throw new NullReferenceException(name);
        }

        public static string MakeSlug(this string slug) =>
            slug == null
                ? null
                : Regex.Replace(slug,
                    @"[^A-Za-z0-9\u0600-\u06FF_\.~]+", "-");

        public static string GetAbsoluteUrl(this HttpContext httpContext) {
            var result = new UriBuilder {
                Scheme = httpContext.Request.Scheme,
                Host = httpContext.Request.Host.ToString(),
                Path = httpContext.Request.Path,
                Query = httpContext.Request.QueryString.ToString()
            };
            return result.Uri.AbsoluteUri;
        }

        public static string AddMessage(this string what, string msg) 
            => string.Format(what, msg);

        public static string GetModelErrorMessages(this ModelStateDictionary modelState) {
            var all = modelState.Values
                .SelectMany(e => e.Errors
                .Select(m => m.ErrorMessage));
            var result = new StringBuilder();
            foreach (var s in all) {
                result.AppendLine(s);
            }

            return result.ToString();
        }
    }
}

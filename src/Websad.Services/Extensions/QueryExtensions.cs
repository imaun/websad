using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Websad.Core.Enum;
using Websad.Core.Models;

namespace Websad.Services.Extensions
{
    public static class QueryExtensions
    {

        public static IQueryable<Category> WhereEnabled(this IQueryable<Category> query) 
            => query.Where(_ => _.Status == EntityStatus.Enabled);
        
        public static IQueryable<Category> WhereDeleted(this IQueryable<Category> query) 
            => query.Where(_ => _.Status == EntityStatus.Deleted);
        
        public static IQueryable<Category> WhereNotDeleted(this IQueryable<Category> query) 
            => query.Where(_ => _.Status != EntityStatus.Deleted);
        
        public static IQueryable<Post> WherePublished(this IQueryable<Post> query) 
            => query.Where(_ => _.Status == PostStatus.Published);
        
        public static IQueryable<Post> WhereDeleted(this IQueryable<Post> query) 
            => query.Where(_ => _.Status == PostStatus.Deleted);
        
        public static IQueryable<Post> WhereNotDeleted(this IQueryable<Post> query)
            => query.Where(_ => _.Status != PostStatus.Deleted);
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Websad.Core.Models;

namespace Websad.Core.Contracts
{
    public interface IWebsadContext: IDisposable
    {
        #region Tables
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostFile> PostFiles { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<PostLike> Likes { get; set; }
        DbSet<PostMeta> PostMeta { get; set; }
        DbSet<SiteVisit> SiteVisits { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Widget> Widgets { get; set; }
        #endregion

        #region Methods
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class;
        int ExecuteSqlCommand(string query);
        Task<int> ExecuteSqlCommandAsync(string query, params object[] parameters);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void SetAsNoTrackingQuery();
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void ExecuteSqlInterpolatedCommand(FormattableString query);
        void ExecuteSqlRawCommand(string query, params object[] parameters);
        #endregion
    }
}

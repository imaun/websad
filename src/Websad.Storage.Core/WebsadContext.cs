using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Websad.Core.Models;
using Websad.Core.Contracts;
using Websad.Storage.Core.Mappings;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Websad.Storage.Core
{
    public class WebsadContext: DbContext, IWebsadContext
    {
        public WebsadContext(DbContextOptions options): base(options) { }

        #region Tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> Likes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostMeta> PostMeta { get; set; }
        public DbSet<PostFile> PostFiles { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<SiteVisit> SiteVisits { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        #endregion

        #region Fields

        private IDbContextTransaction _transaction;

        #endregion

        #region Interface Methods

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class {
            Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class {
            Set<TEntity>().RemoveRange(entities);
        }

        public DatabaseFacade Storage => Database; 

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class {
            Update(entity);
        }

        public int ExecuteSqlCommand(string query) {
            //return Database.ExecuteSqlRaw(query);
            return 0;
        }

        public Task<int> ExecuteSqlCommandAsync(string query, params object[] parameters) {
            //return Database.ExecuteSqlRawAsync(query, parameters);
            return Task.FromResult(0);
        }

        public void SetAsNoTrackingQuery() {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override int SaveChanges() {
            ChangeTracker.DetectChanges();
            //BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess) {
            ChangeTracker.DetectChanges();
            //BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken()) {
            ChangeTracker.DetectChanges();
            //BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            ChangeTracker.DetectChanges();
            //BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public void BeginTransaction() {
            _transaction = Database.BeginTransaction();
        }

        public void RollbackTransaction() {
            if (_transaction == null) {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Rollback();
        }

        public void CommitTransaction() {
            if (_transaction == null) {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Commit();
        }

        public override void Dispose() {
            _transaction?.Dispose();
            base.Dispose();
        }

        public void ExecuteSqlInterpolatedCommand(FormattableString query) {
            //Database.ExecuteSqlInterpolated(query);
        }

        public void ExecuteSqlRawCommand(string query, params object[] parameters) {
            //Database.ExecuteSqlRaw(query, parameters);
        }

        #endregion

        #region Mappings

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.AddCategoryMapping();
            builder.AddCommentMapping();
            builder.AddPostLikeMapping();
            builder.AddPostMapping();
            builder.AddPostFileMapping();
            builder.AddPostMetaMapping();
            builder.AddSiteVisitMapping();
            builder.AddFileMapping();
            builder.AddUserMapping();
            builder.AddWidgetMapping();
            builder.AddBlockMapping();
            builder.AddPostBlockMapping();
            builder.AddBlockSampleMapping();
        }

        #endregion

    }
}

using Microsoft.EntityFrameworkCore;
using Websad.Storage.Core;

namespace Websad.Storage.SQLite
{
    public class SQLiteDbContext: WebsadContext
    {
        public SQLiteDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            //builder.AddDateTimeOffsetConverter();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class PostFileMap
    {
        public static void AddPostFileMapping(this ModelBuilder builder) {
            builder.Entity<PostFile>(map => {
                map.HasKey(_ => _.Id);

                map.HasOne(_ => _.Post)
                    .WithMany(_ => _.Files)
                    .HasForeignKey(_=> _.PostId)
                    .OnDelete(DeleteBehavior.SetNull);

                map.HasOne(_ => _.File)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.FileId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}

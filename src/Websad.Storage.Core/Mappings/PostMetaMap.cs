using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class PostMetaMap
    {
        public static void AddPostMetaMapping(this ModelBuilder builder) {
            builder.Entity<PostMeta>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(250).IsUnicode();
                map.Property(_ => _.Lang).HasMaxLength(20).IsUnicode();
                map.Property(_ => _.MetaKey).HasMaxLength(200).IsUnicode().IsRequired();
                map.Property(_ => _.MetaValue).HasMaxLength(4000).IsUnicode();

                map.HasOne(_ => _.Post)
                    .WithMany(_ => _.Meta)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

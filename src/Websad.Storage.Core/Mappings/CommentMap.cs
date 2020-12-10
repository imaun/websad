using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class CommentMap
    {
        public static void AddCommentMapping(this ModelBuilder builder) {
            builder.Entity<Comment>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Author).IsRequired().HasMaxLength(200).IsUnicode();
                map.Property(_ => _.Email).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Phone).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Message).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.CreateDate).IsRequired();
                map.Property(_ => _.Ip).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.UserAgent).HasMaxLength(200).IsUnicode();
                map.Property(_ => _.SessionId).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Url).HasMaxLength(3000).IsUnicode();

                map.HasOne(_ => _.User)
                    .WithMany(_ => _.Comments)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                map.HasOne(_ => _.Post)
                    .WithMany(_ => _.Comments)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}

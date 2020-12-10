using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class PostLikeMap
    {
        public static void AddPostLikeMapping(this ModelBuilder builder) {
            builder.Entity<PostLike>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.SessionId).HasMaxLength(2000).IsRequired();
                map.Property(_ => _.IP).HasMaxLength(100);
                map.Property(_ => _.CreateDate).IsRequired();

                map.HasOne(_ => _.User)
                   .WithMany(_ => _.Likes)
                   .HasForeignKey(_ => _.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

                map.HasOne(_ => _.Post)
                    .WithMany(_ => _.Likes)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

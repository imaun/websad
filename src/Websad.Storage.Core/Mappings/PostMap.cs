using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class PostMap
    {
        public static void AddPostMapping(this ModelBuilder builder) {
            builder.Entity<Post>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Slug).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Body).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.PostType).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Lang).HasMaxLength(20).IsUnicode();
                map.Property(_ => _.Summary).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Password).HasMaxLength(100);
                map.Property(_ => _.CoverPhoto).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.AltTitle).HasMaxLength(2000).IsUnicode();

                map.HasOne(_ => _.User)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.Category)
                    .WithMany(_ => _.Posts)
                    .HasForeignKey(_ => _.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}

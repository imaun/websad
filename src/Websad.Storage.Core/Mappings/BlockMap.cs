using System;
using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings {

    public static class BlockMap {

        public static void AddBlockMapping(this ModelBuilder builder) {
            builder.Entity<Block>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Attributes);
                map.Property(_ => _.Author).HasMaxLength(300).IsUnicode().IsRequired();
                map.Property(_ => _.AuthorEmail).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Category).HasMaxLength(100).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Icon).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.ImagePath).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.Keywords).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Name).HasMaxLength(300).IsUnicode().IsRequired();
                map.Property(_ => _.Src).IsRequired();
                map.Property(_ => _.Title).HasMaxLength(300).IsUnicode().IsRequired();

                map.HasOne(_ => _.Parent)
                    .WithMany(_ => _.InnerBlocks)
                    .HasForeignKey(_ => _.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.AddedByUser)
                    .WithMany(_ => _.AddedBlocks)
                    .HasForeignKey(_ => _.AddedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddPostBlockMapping(this ModelBuilder builder) {
            builder.Entity<PostBlock>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.OutputSrc).IsUnicode().IsRequired();

                map.HasOne(_ => _.Post)
                    .WithMany(_ => _.PostBlocks)
                    .HasForeignKey(_ => _.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                map.HasOne(_ => _.Block)
                    .WithMany(_ => _.PostBlocks)
                    .HasForeignKey(_ => _.BlockId)
                    .OnDelete(DeleteBehavior.Restrict);

                map.HasOne(_ => _.User)
                    .WithMany(_ => _.AddedPostBlocks)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void AddBlockSampleMapping(this ModelBuilder builder) {
            builder.Entity<BlockSample>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(300).IsUnicode().IsRequired();
                map.Property(_ => _.Attributes).IsUnicode();
                map.Property(_ => _.OutputSrc).IsRequired();
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();

                map.HasOne(_ => _.Block)
                    .WithMany(_ => _.Samples)
                    .HasForeignKey(_ => _.BlockId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

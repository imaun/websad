using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class FileMap
    {
        public static void AddFileMapping(this ModelBuilder builder) {
            builder.Entity<File>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(250).IsUnicode();
                map.Property(_ => _.FileName).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.FilePath).HasMaxLength(2000).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();

                map.HasOne(_ => _.User)
                    .WithMany(_ => _.Files)
                    .HasForeignKey(_ => _.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

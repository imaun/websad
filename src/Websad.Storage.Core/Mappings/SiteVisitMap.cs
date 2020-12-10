using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class SiteVisitMap
    {
        public static void AddSiteVisitMapping(this ModelBuilder builder) {
            builder.Entity<SiteVisit>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.SessionId).HasMaxLength(1000).IsRequired();
                map.Property(_ => _.AbsoluteUrl).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.UrlReferrer).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.IP).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.UserAgent).HasMaxLength(100);
                map.Property(_ => _.OsPlatform).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Country).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.City).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Region).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();

            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Websad.Core.Models;

namespace Websad.Storage.Core.Mappings
{
    public static class WidgetMap
    {
        public static void AddWidgetMapping(this ModelBuilder builder) {
            builder.Entity<Widget>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Body).HasMaxLength(4000).IsUnicode();
                map.Property(_ => _.Category).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Lang).HasMaxLength(20).IsUnicode();
                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.UniqueName).HasMaxLength(250).IsUnicode().IsRequired();
                
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Websad.Core;
using Websad.Core.Enum;
using Websad.Core.Models;
using Websad.Resources;

namespace Websad.Storage.Core.Mappings
{
    public static class CategoryMap
    {
        public static void AddCategoryMapping(this ModelBuilder builder) {
            builder.Entity<Category>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(250).IsUnicode().IsRequired();
                map.Property(_ => _.Slug).HasMaxLength(400).IsUnicode().IsRequired();
                map.Property(_ => _.Description).HasMaxLength(500).IsUnicode();
                map.Property(_ => _.Lang).HasMaxLength(20).IsUnicode();
                map.Property(_ => _.PostType).HasMaxLength(100).IsUnicode();

                map.HasData(new Category {
                    Id = 1,
                    Slug = AppText.UncategorizedSlug,
                    Status = EntityStatus.Enabled,
                    Title = AppText.UncategoriezdTitle,
                    PostType = AppConst.PostTypePage,
                    Lang = AppConst.LangFa
                });
            });
        }
    }
}

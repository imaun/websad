using Microsoft.EntityFrameworkCore;
using System;
using Websad.Core;
using Websad.Core.Contracts;
using Websad.Core.Enum;
using Websad.Core.Models;
using Websad.Core.Utils;

namespace Websad.Storage.Core.Mappings
{
    public static class UserMap
    {

        private static readonly IUserApiKeyGenerator _apiKeyGenerator
            = new UserApiKeyGenerator();

        public static void AddUserMapping(this ModelBuilder builder) {
            builder.Entity<User>(map => {
                map.HasKey(_ => _.Id);

                map.Property(_ => _.Title).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Username).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.Email).HasMaxLength(1000).IsUnicode().IsRequired();
                map.Property(_ => _.PasswordHash).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.WebUrl).HasMaxLength(2000);
                map.Property(_ => _.Phone).HasMaxLength(100).IsUnicode();
                map.Property(_ => _.Role).HasMaxLength(20).IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();

                map.HasData(new User {
                    Status = UserStatus.Enabled,
                    Username = "modir",
                    PasswordHash = "slm77M0diT3o".GetHashOfString(),
                    Email = "admin@site.com",
                    Id = 1,
                    Title = "Admin",
                    RegisterDate = DateTime.UtcNow,
                    Enabled = true,
                    Role = AppConst.RoleAdmin,
                    LockoutEnabled = false,
                    ApiKey = _apiKeyGenerator.GetNewApiKey()
                });
            });
        }
    }
}

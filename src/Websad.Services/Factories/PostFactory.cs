using System.Threading.Tasks;
using Mapster;
using Websad.Core.Contracts;
using Websad.Core.Enum;
using Websad.Core.Extensions;
using Websad.Core.Models;
using Websad.Core.Security;
using Websad.Core.Utils;
using Websad.Services.Data;
using Websad.Services.Data.Mapping;

namespace Websad.Services.Factories
{
    public interface IPostFactory {
        Post Make(PostCreateDto model);
        Task<Post> MakeAsync(PostUpdateDto model);
    }

    public class PostFactory : IPostFactory {
        private readonly HttpUserInfo _userInfo;
        private readonly IDateService _dateService;
        private readonly IWebsadContext _db;

        public PostFactory(
            IDateService dateService,
            HttpUserInfo userInfo,
            IWebsadContext db) {
            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            userInfo.CheckArgumentIsNull(nameof(userInfo));
            _userInfo = userInfo;

            db.CheckArgumentIsNull(nameof(db));
            _db = db;
        }

        public Post Make(PostCreateDto model) {
            model.CheckArgumentIsNull();
            var entity = model.Adapt<Post>();
            entity.UserId = _userInfo.UserId;

            entity.Slug = entity.Slug.MakeSlug();
            if (string.IsNullOrWhiteSpace(entity.Slug))
                entity.Slug = entity.Title.MakeSlug();

            entity.CreateDate = 
                entity.ModifyDate = _dateService.UtcNow();
            
            if (model.Status == PostStatus.Published)
                entity.PublishDate = _dateService.UtcNow();

            if (!string.IsNullOrWhiteSpace(model.Password))
                entity.Password = model.Password.GetHashOfString();

            return entity;
        }


        public async Task<Post> MakeAsync(PostUpdateDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var entity = await _db.Posts.FindAsync(model.Id);
            entity.CheckReferenceIsNull(nameof(entity));
            
            entity.GetUpdateData(model);
            
            entity.Slug = entity.Slug.MakeSlug();
            if (string.IsNullOrWhiteSpace(entity.Slug))
                entity.Slug = entity.Title.MakeSlug();

            if (!string.IsNullOrWhiteSpace(model.Password))
                entity.Password = model.Password.GetHashOfString();

            entity.ModifyDate = _dateService.UtcNow();
            entity.UserId = _userInfo.UserId;

            return entity;
        }

    }
}

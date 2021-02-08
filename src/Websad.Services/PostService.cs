using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Websad.Services.Data;
using Websad.Core.Contracts;
using Websad.Core.Enum;
using Websad.Core.Extensions;
using Websad.Services.Contracts;
using Websad.Services.Factories;
using Websad.Core.Models;

namespace Websad.Services {

    public class PostService : IPostService {

        private readonly IWebsadContext _db;
        private readonly IPostFactory _factory;
        private readonly IDateService _dateService;

        public PostService(
            IWebsadContext db,
            IPostFactory factory,
            IDateService dateService
        ) {
            db.CheckArgumentIsNull();
            _db = db;

            factory.CheckArgumentIsNull();
            _factory = factory;

            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;
        }

        public async Task<PostResultDto> CreateAsync(PostCreateDto model) {
            var entity = _factory.Make(model);
            await _db.Posts.AddAsync(entity);
            await _db.SaveChangesAsync();

            return await Task.FromResult(entity.Adapt<PostResultDto>());
        }

        public async Task<PostResultDto> UpdateAsync(PostUpdateDto model) {
            var entity = await _factory.MakeAsync(model);
            _db.Posts.Update(entity);
            await _db.SaveChangesAsync();

            return await Task.FromResult(entity.Adapt<PostResultDto>());
        }

        public async Task<PostDetailDto> GetPostDetailAsync(
            string postType, 
            string slug) {
            var post = await getDetailQuery()
                .FirstOrDefaultAsync(_ => _.PostType == postType 
                                          && _.Slug == slug
                                          && _.Status == PostStatus.Published
                                          && _.PublishDate <= _dateService.UtcNow());
            return await output(post);
        }

        public async Task<int> GetCommentsCountAsync(int postId) 
            => await _db.Comments.CountAsync(_ => _.PostId == postId);

        public async Task<int> GetLikesCountAsync(int postId)
            => await _db.Likes.CountAsync(_ => _.PostId == postId);

        public async Task<PostDetailDto> GetPostDetailAsync(
            string postType, 
            string slug, 
            int categoryId) {
            var post = await getDetailQuery()
                .FirstOrDefaultAsync(_ => _.PostType == postType
                                          && _.Slug == slug
                                          && _.CategoryId == categoryId
                                          && _.Status == PostStatus.Published
                                          && _.PublishDate <= _dateService.UtcNow());
            return await output(post);
        }

        public async Task<PostDetailDto> GetPostDetailAsync(int id) {
            var post = await getDetailQuery()
                .FirstOrDefaultAsync(_ => _.Id == id);

            return await output(post);
        }

        public async Task<PostResultDto> GetPostAsync(int id) {
            var post = await _db.Posts.FindAsync(id);

            if (post == null)
                return null;

            var result = post.Adapt<PostResultDto>();
            return await Task.FromResult(result);
        }

        public async Task<PostViewListDto> GetPublishedViewListAsync(
            ViewListParam<PostViewListFilter> param
        ) {
            
            var query = _db.Posts
                .Include(_ => _.User)
                .Where(_ => _.Status == PostStatus.Published);

            if(param.Filter != null) {
                if (!string.IsNullOrWhiteSpace(param.Filter.PostType))
                    query = query.Where(_ => _.PostType.ToUpper() == param.Filter.PostType.ToUpper());

                if (!string.IsNullOrWhiteSpace(param.Filter.Title))
                    query = query.Where(_ => _.Title.Contains(param.Filter.Title));

                if (!string.IsNullOrWhiteSpace(param.Filter.Lang))
                    query = query.Where(_ => _.Lang.ToUpper() == param.Filter.Lang.ToUpper());
            }


            query = query
                .OrderByDescending(_ => _.PublishDate)
                .OrderByDescending(_ => _.OrderNumber);

            var result = new PostViewListDto {
                Items = await query
                    .Skip(param.Skip)
                    .Take(param.PageSize)
                    .Select(_ => new PostViewItemDto {
                        Slug = _.Slug,
                        Title = _.Title,
                        Author = _.User.Title,
                        CommentsCount = _.Comments.Count(),
                        LikesCount = _.Likes.Count(),
                        Id = _.Id,
                        PublishDate = _.PublishDate.Value,
                        Summary = _.Summary,
                        Tags = _.Tags,
                        AltTitle = _.AltTitle,
                        CoverPhoto = _.CoverPhoto
                    }).ToListAsync(),
                TotalCount = query.Count(),
                PageIndex = param.PageIndex,
                PageSize = param.PageSize
            };

            return await Task.FromResult(result);
        }

        public async Task<PostDetailDto> GetPostDetailAsync(
            string postType, 
            string slug, 
            string categorySlug) {
            var post = await getDetailQuery()
                .FirstOrDefaultAsync(_ => _.PostType == postType
                                          && _.Slug == slug
                                          && _.Category.Slug.ToUpper() == categorySlug.ToUpper()
                                          && _.Status == PostStatus.Published
                                          && _.PublishDate <= _dateService.UtcNow());

            return await output(post);
        }

        #region Private Helper Methods
        private IQueryable<Post> getDetailQuery()
            => _db.Posts
                .Include(_ => _.User)
                .Include(_ => _.Category)
                .Include(_ => _.Meta)
                .Include(_ => _.Files)
                .ThenInclude(_ => _.File)
                .Include(_ => _.PostBlocks)
                .ThenInclude(_ => _.Block);

        private async Task<PostDetailDto> output(Post post) {
            if (post == null)
                return null;

            var result = new PostDetailDto {
                Id = post.Id,
                Post = post.Adapt<PostResultDto>()
            };
            result.Post.CommentsCount = await GetCommentsCountAsync(post.Id);
            result.Post.LikesCount = await GetLikesCountAsync(post.Id);

            return result;
        }

        #endregion
    }
}

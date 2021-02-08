using System.Threading.Tasks;
using Websad.Services.Data;

namespace Websad.Services.Contracts
{
    public interface IPostService
    {
        Task<PostResultDto> CreateAsync(PostCreateDto model);
        Task<PostResultDto> UpdateAsync(PostUpdateDto model);
        Task<PostDetailDto> GetPostDetailAsync(int id);
        Task<PostDetailDto> GetPostDetailAsync(string postType, string slug);
        Task<PostDetailDto> GetPostDetailAsync(
            string postType,
            string slug,
            int categoryId);
        Task<PostDetailDto> GetPostDetailAsync(
            string postType,
            string slug,
            string categorySlug);
        Task<PostResultDto> GetPostAsync(int id);
        Task<PostViewListDto> GetPublishedViewListAsync(
            ViewListParam<PostViewListFilter> param);

        Task<int> GetCommentsCountAsync(int postId);
        Task<int> GetLikesCountAsync(int postId);
    }
}

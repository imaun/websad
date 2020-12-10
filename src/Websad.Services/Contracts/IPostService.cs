using System.Threading.Tasks;
using Websad.Services.Data;

namespace Websad.Services.Contracts
{
    public interface IPostService
    {
        Task<PostResultDto> CreateAsync(PostCreateDto model);
        Task<PostResultDto> UpdateAsync(PostUpdateDto model);
        Task<PostResultDto> GetPostDetailAsync(int id);
        Task<PostResultDto> GetPostDetailAsync(string postType, string slug);
        Task<PostResultDto> GetPostAsync(int id);
        Task<PostViewListDto> GetPublishedViewListAsync(ViewListParam<PostViewListFilter> param);
    }
}

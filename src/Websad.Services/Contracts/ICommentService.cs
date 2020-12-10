using System.Threading.Tasks;
using Websad.Services.Data;

namespace Websad.Services.Contracts
{
    public interface ICommentService
    {
        Task<CommentResultDto> CreateAsync(CommentCreateDto model);
    }
}

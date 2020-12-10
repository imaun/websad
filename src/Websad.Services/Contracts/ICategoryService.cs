using System.Collections.Generic;
using System.Threading.Tasks;
using Websad.Services.Data;

namespace Websad.Services.Contracts
{
    public interface ICategoryService {
        Task<CategoryResultDto> CreateAsync(CategoryCreateDto model);
        Task<CategoryResultDto> UpdateAsync(CategoryUpdateDto model);
        Task<bool> AnyAsync(int id);
        Task<CategoryResultDto> GetResultByIdAsync(int id);
        Task<IEnumerable<PostTypeCategoryItemDto>> GetPostTypeCategoriesAsync(
            string postType
        );
    }
}

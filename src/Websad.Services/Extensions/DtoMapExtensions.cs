using Mapster;
using Websad.Core.Models;
using Websad.Services.Data;

namespace Websad.Services.Extensions
{
    public static class DtoMapExtensions
    {

        public static void AddDtoMapping() {
            TypeAdapterConfig<Post, PostResultDto>
                .NewConfig()
                .Map(dest => dest.UserTitle, 
                    src => src.User.Title)
                .Map(dest => dest.CategoryTitle, 
                    src => src.Category.Title)
                .Map(dest => dest.CommentsCount, 
                    src => src.Comments != null ? src.Comments.Count : 0)
                .Map(dest => dest.LikesCount, 
                    src => src.Likes != null ? src.Likes.Count : 0);

        }

    }
}

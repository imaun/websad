using Websad.Core.Models;

namespace Websad.Services.Data.Mapping
{
    public static class DtoMapExt
    {

        public static void GetUpdateData(this Post post, PostUpdateDto model) {
            post.Slug = model.Slug;
            post.Title = model.Title;
            post.PublishDate = model.PublishDate;
            post.AltTitle = model.AltTitle;
            post.Body = model.Body;
            post.CategoryId = model.CategoryId;
            post.Commenting = model.Commenting;
            post.CoverPhoto = model.CoverPhoto;
            post.Lang = model.Lang;
            post.OrderNumber = model.OrderNumber;
            post.ParentId = model.ParentId;
            post.Tags = model.Tags;
            post.PostType = model.PostType;
        }

        public static void GetUpdateData(this Category category, CategoryUpdateDto model) {
            category.Slug = model.Slug;
            category.Title = model.Title;
            category.Description = model.Description;
            category.Lang = model.Lang;
            category.ParentId = model.ParentId;
            category.PostType = model.PostType;
            category.Status = model.Status;
        }

    }
}

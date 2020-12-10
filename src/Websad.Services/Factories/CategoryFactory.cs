using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore.Metadata;
using Websad.Core.Contracts;
using Websad.Core.Extensions;
using Websad.Core.Models;
using Websad.Services.Data;
using Websad.Services.Data.Mapping;

namespace Websad.Services.Factories
{
    public interface ICategoryFactory {
        Category Make(CategoryCreateDto model);
       Task<Category> MakeAsync(CategoryUpdateDto model);
    }


    public class CategoryFactory: ICategoryFactory {
        private readonly IWebsadContext _db;

        public CategoryFactory(IWebsadContext db) {
            db.CheckArgumentIsNull(nameof(db));
            _db = db;
        }

        public Category Make(CategoryCreateDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var category = model.Adapt<Category>();
            category.Slug = string.IsNullOrWhiteSpace(model.Slug)
                ? model.Title.MakeSlug()
                : model.Slug.MakeSlug();

            return category;
        }

        public async Task<Category> MakeAsync(CategoryUpdateDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var entity = await _db.Categories.FindAsync(model.Id);
            entity.GetUpdateData(model);
            entity.Slug = string.IsNullOrWhiteSpace(model.Slug) 
                ? model.Title.MakeSlug() 
                : entity.Slug.MakeSlug();

            return entity;
        }
    }
}

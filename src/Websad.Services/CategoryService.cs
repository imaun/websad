using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Websad.Core.Contracts;
using Websad.Core.Enum;
using Websad.Core.Exceptions;
using Websad.Core.Extensions;
using Websad.Core.Models;
using Websad.Services.Contracts;
using Websad.Services.Data;
using Websad.Services.Extensions;
using Websad.Services.Factories;

namespace Websad.Services
{
    public class CategoryService: ICategoryService {
        
        private readonly IWebsadContext _db;
        //private readonly DbSet<Category> _dbSet;
        private readonly ICategoryFactory _factory;

        public CategoryService(IWebsadContext db,
            ICategoryFactory factory) {
            db.CheckArgumentIsNull(nameof(db));
            _db = db;

            //_dbSet = _db.Set<Category>();

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;
        }

        private async Task<bool> ValidateCreateAsync(Category model) {
            model.CheckArgumentIsNull(nameof(model));
            if(string.IsNullOrWhiteSpace(model.Title))
                throw new ArgumentNullException(nameof(model.Title));
            if(string.IsNullOrWhiteSpace(model.Slug))
                throw new ArgumentNullException(nameof(model.Slug));

            if(await _db.Categories
                .AnyAsync(_ => _.Title == model.Title))
                throw new TitleExistException(nameof(model.Title));

            if(await _db.Categories
                .AnyAsync(_=> _.Slug == model.Slug))
                throw new SlugExistException(nameof(model.Slug));

            return await Task.FromResult(true);
        }

        private async Task<bool> ValidateUpdateAsync(Category model) {
            model.CheckArgumentIsNull(nameof(model));
            if(string.IsNullOrWhiteSpace(model.Title))
                throw new ArgumentNullException(nameof(model.Title));
            if(string.IsNullOrWhiteSpace(model.Slug))
                throw new ArgumentNullException(nameof(model.Slug));
            
            if(await _db.Categories
                .AnyAsync(_=> _.Title.ToLower() == model.Title.ToLower()
                    && _.Id != model.Id))
                throw new TitleExistException($"[Category] Title : '{model.Title}' existed.");
            
            if(await _db.Categories
                .AnyAsync(_=> _.Slug.ToLower() == model.Slug.ToLower()
                    && _.Id != model.Id))
                throw new SlugExistException(nameof(model.Slug));
            
            return await Task.FromResult(true);
        }

        public async Task<CategoryResultDto> CreateAsync(CategoryCreateDto model) {
            var entity = _factory.Make(model);
            await ValidateCreateAsync(entity);
            await _db.Categories.AddAsync(entity);
            await _db.SaveChangesAsync();

            var result = entity.Adapt<CategoryResultDto>();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PostTypeCategoryItemDto>> GetPostTypeCategoriesAsync(
            string postType
        ) =>
            await _db.Categories
                .WhereEnabled()
                .Where(_ => _.PostType.ToLower() == postType.ToLower())
                .Select(_=> new PostTypeCategoryItemDto {
                    Title = _.Title,
                    Description = _.Description,
                    Id = _.Id,
                    ParentId = _.ParentId
                }).ToListAsync();

        public Task<CategoryResultDto> UpdateAsync(CategoryUpdateDto model) {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(int id) 
            => await _db.Categories.AnyAsync(_=> _.Id == id);
        
        public async Task<CategoryResultDto> GetResultByIdAsync(int id) {
            var category = await _db.Categories.FirstOrDefaultAsync(_=> _.Id == id);
            var result = category.Adapt<CategoryResultDto>();
            return await Task.FromResult(
                result
            );
        }
    }
}

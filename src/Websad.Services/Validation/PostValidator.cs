using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Websad.Core.Contracts;
using Websad.Core.Exceptions;
using Websad.Core.Extensions;
using Websad.Services.Data;

namespace Websad.Services.Validation
{
    public class PostValidator {
        private readonly IWebsadContext _db;

        public PostValidator(IWebsadContext db) {
            db.CheckArgumentIsNull(nameof(db));
            _db = db;
        }

        private async Task<bool> CategoryExistAsync(int categoryId)
            => await _db.Categories.AnyAsync(_ => _.Id == categoryId);
        

        public async Task ValidateAsync(PostCreateDto model) {
            model.CheckArgumentIsNull(nameof(model));
            if(string.IsNullOrWhiteSpace(model.Title))
                throw new ArgumentNullException(nameof(model.Title));

            if(!await CategoryExistAsync(model.CategoryId))
                throw new CategoryNotExistException($"Category with id:{model.CategoryId} does not exist.");
        }

    }
}

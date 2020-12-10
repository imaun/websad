using System.Threading.Tasks;
using Mapster;
using Websad.Core.Contracts;
using Websad.Core.Extensions;
using Websad.Services.Contracts;
using Websad.Services.Data;
using Websad.Services.Factories;

namespace Websad.Services
{
    public class CommentService : ICommentService
    {

        private readonly IDateService _dateService;
        private readonly IWebsadContext _db;
        private readonly ICommentFactory _factory;

        public CommentService(
            IDateService dateService,
            IWebsadContext db,
            ICommentFactory factory
        ) {
            dateService.CheckArgumentIsNull();
            _dateService = dateService;

            db.CheckArgumentIsNull();
            _db = db;

            factory.CheckArgumentIsNull();
            _factory = factory;
        }

        public async Task<CommentResultDto> CreateAsync(CommentCreateDto model) {
            var entity = _factory.Make(model);
            await _db.Comments.AddAsync(entity);
            await _db.SaveChangesAsync();
            var result = entity.Adapt<CommentResultDto>();

            return await Task.FromResult(result);
        }
    }
}

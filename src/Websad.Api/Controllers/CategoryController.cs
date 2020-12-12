using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Websad.Api.Models;
using Websad.Core.Exceptions;
using Websad.Core.Extensions;
using Websad.Services.Contracts;
using Websad.Services.Data;

namespace Websad.Api.Controllers
{
    [Route("api/category")]
    [Authorize]
    public class CategoryController: WebsadBaseApiController {

        private readonly ICategoryService _categoryService;

        public CategoryController(IUserService userService,
            ICategoryService categoryService) : base(userService) {

            categoryService.CheckArgumentIsNull(nameof(categoryService));
            _categoryService = categoryService;
        }

        [HttpPost("[action]")]
        //[AuthorizeApiKey]
        public async Task<IActionResult> Create(
            [FromBody] CategoryCreateApiModel model) {

            model.CheckArgumentIsNull(nameof(model));

            var data = model.Adapt<CategoryCreateDto>();
            
            CategoryResultDto category;
            try {
                category = await _categoryService.CreateAsync(data);
            }
            catch (TitleExistException e) {
                return BadRequest(new ApiModel<CategoryApiModel> {
                    HasError = true,
                    Message = "Title exist"
                });
            }
            catch(SlugExistException e)
            {
                return BadRequest(new ApiModel<CategoryApiModel> {
                    HasError = true,
                    Message = "Slug exist"
                });
            }
            catch(Exception e) {
                return BadRequest(new ApiModel<CategoryApiModel> {
                    HasError = true,
                    Message = e.GetBaseException().Message
                });
            }
            
            return Ok(new ApiModel<CategoryApiModel> {
                Model = category.Adapt<CategoryApiModel>()
            });
        }


    }
}

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
using Websad.Resources;
using System.Collections.Generic;

namespace Websad.Api.Controllers {

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

        [HttpGet("[action]/{postType}")]
        public async Task<IActionResult> Get([FromRoute]string postType) {
            if (string.IsNullOrWhiteSpace(postType))
                return BadRequest(new CategoryListApiModel {
                    HasError = true,
                    Message = ApiTextDisplay.InsufficientParams
                        .AddMessage(nameof(postType)),
                    Model = null
                });

            var cats = await _categoryService
                .GetPostTypeCategoriesAsync(postType);
            var result = new CategoryListApiModel(postType) {
                Model = cats.Adapt<List<CategoryApiModel>>()
            };

            return Ok(result);
        }

    }
}

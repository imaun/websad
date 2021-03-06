﻿using System;
using System.Net;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Websad.Api.Models;
using Websad.Api.Utils;
using Websad.Core.Extensions;
using Websad.Resources;
using Websad.Services.Contracts;
using Websad.Services.Data;

namespace Websad.Api.Controllers
{
    [Route("api/post")]
    [Authorize]
    public class PostController: WebsadBaseApiController {

        private readonly IPostService _postService;
        private readonly FileUploadHelper _fileUploader;

        public PostController(
            IUserService userService,
            IPostService postService,
            FileUploadHelper fileUploader): base(userService) {

            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;

            fileUploader.CheckArgumentIsNull(nameof(fileUploader));
            _fileUploader = fileUploader;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(
            [FromBody]PostCreateApiModel model
        ) {
            model.CheckArgumentIsNull(nameof(model));

            if(!ModelState.IsValid) {
                return Ok(new ApiModel<PostApiModel> {
                    HasError = true,
                    Model = null,
                    Message = ModelState.GetModelErrorMessages()
                });
            }

            string coverPhotoUrl = null;
            if(model.CoverPhotoFile != null && model.CoverPhotoFile.Length > 0) {
                var uploadResult = await _fileUploader
                    .UploadPhotoAsync(model.CoverPhotoFile);
                if (uploadResult.HasError) {
                    return BadRequest(new ApiModel<PostApiModel> {
                        Message = ApiTextDisplay.UploadPhotoFailedWith
                            .AddMessage(uploadResult.ErrorMessage),
                        Model = null
                    });
                }
                coverPhotoUrl = uploadResult.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(model.CoverPhotoUrl))
                coverPhotoUrl = model.CoverPhotoUrl;
            
            var postData = model.Adapt<PostCreateDto>();
            postData.CoverPhoto = coverPhotoUrl;
            PostResultDto serviceResult;
            try {
                serviceResult = await _postService.CreateAsync(postData);
            }
            catch (Exception e) {
                return Ok(new ApiModel<PostApiModel> {
                    HasError = true,
                    Model = null,
                    Message = e.GetBaseException().Message
                });
            }

            var result = new ApiModel<PostApiModel> {
                Model = serviceResult.Adapt<PostApiModel>(),
                Message = ApiTextDisplay.SuccessOperation
            };

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(
            [FromBody]PostUpdateApiModel model
        ) {
            model.CheckArgumentIsNull(nameof(model));
            if (!ModelState.IsValid) {
                return BadRequest(new ApiModel<PostApiModel> {
                    HasError = true,
                    Model = null
                });
            }

            string coverPhotoUrl = null;
            if (model.CoverPhotoFile != null && model.CoverPhotoFile.Length > 0) {
                var uploadResult = await _fileUploader
                    .UploadPhotoAsync(model.CoverPhotoFile);
                if (uploadResult.HasError) {
                    return BadRequest(new ApiModel<PostApiModel> {
                        Message = ApiTextDisplay.UploadPhotoFailedWith
                            .AddMessage(uploadResult.ErrorMessage),
                        Model = null
                    });
                }
                coverPhotoUrl = uploadResult.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(model.CoverPhotoUrl))
                coverPhotoUrl = model.CoverPhotoUrl;

            var data = model.Adapt<PostUpdateDto>();
            data.CoverPhoto = coverPhotoUrl;
            PostResultDto serviceResult;

            try {
                serviceResult = await _postService.UpdateAsync(data);
            }
            catch (Exception e) {
                return BadRequest(new ApiModel<PostApiModel> {
                    Model = null,
                    HasError = true,
                    Message = e.GetBaseException().Message
                });
            }

            var result = new ApiModel<PostApiModel> {
                Model = serviceResult.Adapt<PostApiModel>(),
                Message = ApiTextDisplay.SuccessOperation
            };

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id) {
            var post = await _postService.GetPostAsync(id);
            try {
                post.CheckReferenceIsNull(nameof(post));
                var result = new ApiModel<PostApiModel> {
                    Model = post.Adapt<PostApiModel>(),
                    Message = ApiTextDisplay.SuccessOperation
                };

                return Ok(result);
            }
            catch(NullReferenceException e) {
                return NotFound(new ApiModel<PostApiModel> {
                    HasError = true,
                    Model = null,
                    Message = ApiTextDisplay.NotFound
                });
            }
            catch(Exception e) {
                return BadRequest(new ApiModel<PostApiModel> {
                    HasError = true,
                    Model = null,
                    Message = e.GetBaseException().Message
                });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Websad.Core.Extensions;
using Websad.Services.Contracts;
using Websad.Web.ViewModels;

namespace Websad.Web.Components
{
    [ViewComponent]
    public class PostViewComponent: ViewComponent
    {
        private readonly IPostService _postService;

        public PostViewComponent(IPostService postService) {
            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }


        public async Task<IViewComponentResult> InvokeAsync(
            string postType, 
            string slug) {
            var post = _postService.GetPostDetailAsync(postType, slug);
            if (post == null)
                return Content(string.Empty);

            var result = post.Adapt<PostViewModel>();

            return await Task.FromResult(
                View(result)
            );
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Websad.Core.Extensions;
using Websad.Services.Contracts;
using Websad.Web.ViewModels;
using Websad.Web.ViewModels.Components;

namespace Websad.Web.Components
{
    public class CategoryListViewComponent: ViewComponent {
        
        private readonly ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService) {
            categoryService.CheckArgumentIsNull(nameof(categoryService));
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string postType,
            string lang = "fa"
        ) {
            var result = new CategoryListViewComponentModel();
            var categories = await _categoryService
                .GetPostTypeCategoriesAsync(postType);
            result.Items = categories
                .Adapt<List<PostTypeCategoryItemViewModel>>();

            return View(result);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Websad.Web.Components
{
    [ViewComponent(Name = "RecentBlogPosts")]
    public class RecentBlogPostsViewComponent: ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync() {

            return View();
        }
    }
}

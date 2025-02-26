using Gut_Cleanse.Service.BlogsService;
using Gut_Cleanse.Service.ProgramsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogsService _blogsService;
        public BlogsController(IBlogsService blogsService)
        {
            _blogsService = blogsService;
        }
        public IActionResult Index()
        {
            var blogs = _blogsService.GetBlogs();
            return View(blogs);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var blogs = _blogsService.GetBlogs();
            return View(blogs);
        }

        public IActionResult View(int id)
        {
            var blogs = _blogsService.GetBlogsById(id);
            return View(blogs);
        }

    }
}

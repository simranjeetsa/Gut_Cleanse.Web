using Gut_Cleanse.Service.BlogsService;
using Gut_Cleanse.Service.ProgramsService;
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

        public IActionResult Step_Approach()
        {
            var blogs = _blogsService.GetBlogsById(1);
            return View(blogs);
        }
        public IActionResult Remedies()
        {
            var blogs = _blogsService.GetBlogsById(2);
            return View(blogs);
        }
        
    }
}

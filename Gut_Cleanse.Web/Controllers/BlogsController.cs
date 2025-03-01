using Gut_Cleanse.Data;
using Gut_Cleanse.Model;
using Gut_Cleanse.Service.BlogsService;
using Gut_Cleanse.Service.CommonService;
using Gut_Cleanse.Service.ProgramsService;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogsService _blogsService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BlogsController(IBlogsService blogsService, IWebHostEnvironment webHostEnvironment)
        {
            _blogsService = blogsService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var blogs = _blogsService.GetBlogs();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            var blogs = _blogsService.GetBlogsById(Id);
            return View(blogs);
        }
        [Authorize(Roles = "Admin")]
        //public IActionResult Create()
        //{
        //    var blogs = _blogsService.GetBlogs();
        //    return View(blogs);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(BlogModel model)
        {
            try
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();
                if (file != null && file.Length > 0)
                {
                    var directory = _webHostEnvironment.WebRootPath + "\\Assets\\blog";
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid();
                    var filePath = Path.Combine(directory, fileName + extension);

                    if (!System.IO.Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.ImageUrl = "/Assets/blog/" + fileName + extension;
                    if (model.Id > 0)
                    {
                        _blogsService.AddBlog(model);
                        TempData["ToastrMessage"] = "Blogs updated successfully!";
                        TempData["ToastrType"] = "success";
                    }
                }

                else
                {
                    _blogsService.AddBlog(model);
                    TempData["ToastrMessage"] = "Blogs created successfully!";
                    TempData["ToastrType"] = "success";

                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {

                TempData["ToastrMessage"] = ex.Message;
                TempData["ToastrType"] = "error";
            }

            return View(model);
        }
        public IActionResult View(int id)
        {
            var blogs = _blogsService.GetBlogsById(id);
            return View(blogs);
        }
        public IActionResult List()
        {

            return View(_blogsService.GetBlogs());

        }
        public IActionResult DeleteBlogs(int id)
        {
            try
            {
                if (id > 0)
                {
                    _blogsService.DeleteBlog(id);
                    TempData["ToastrMessage"] = "Blogs deleted successfully!";
                    TempData["ToastrType"] = "success";
                }
            }
            catch (Exception ex)
            {
                TempData["ToastrMessage"] = ex.Message;
                TempData["ToastrType"] = "error";
            }


            return RedirectToAction("List");


        }
    }
}

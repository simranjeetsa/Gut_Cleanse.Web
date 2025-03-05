using Gut_Cleanse.Common;
using Gut_Cleanse.Data;
using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;

namespace Gut_Cleanse.Repo.BlogsRepo
{
    public class BlogsRepo : IBlogsRepo
    {
        private readonly ApplicationDbContext _context;
        public BlogsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogModel> GetBlogs()
        {
            List<BlogModel> result = new List<BlogModel>();
            result.AddRange(_context.Blogs
                .Where(x => !x.IsDeleted) 
                .Select(x => x.AutoMap<BlogModel>())
                .ToList());
            return result;
        }

        public BlogModel GetBlogsById(int Id)
        {
            BlogModel result = new BlogModel();
            var program = _context.Blogs.FirstOrDefault(x => x.Id == Id);
            if (program != null)
            {
                result.Id = Id;
                result.CreateDate = program.CreateDate;
                result.MainDescription = program.MainDescription;
                result.Description = program.Description;
                result.ImageUrl = program.ImageUrl;
                result.Title = program.Title;
            }
            return result;
        }

        public void AddBlog(BlogModel model)
        {
            var data = _context.Blogs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.CreateDate = model.CreateDate;
                data.MainDescription = model.MainDescription;
                data.Description = model.Description;
                data.ImageUrl = model.ImageUrl;
                data.Title = model.Title;
            }
            else
            {
                Blog blog = new Blog()
                {
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    MainDescription = model.MainDescription,
                    Title = model.Title,
                    CreateDate = model.CreateDate,
                };
                _context.Blogs.Add(blog);
            }
            _context.SaveChanges();
        }
 
        public void DeleteBlog(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(s => s.Id == id);
            if (blog == null) return;

            _context.Blogs.Remove(blog); 
            _context.SaveChanges();
        }
    }
}

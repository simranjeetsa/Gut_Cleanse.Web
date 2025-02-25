using Gut_Cleanse.Common;
using Gut_Cleanse.Data;
using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            result.AddRange(_context.Blogs.Select(x => x.AutoMap<BlogModel>()).ToList());
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
    }
}

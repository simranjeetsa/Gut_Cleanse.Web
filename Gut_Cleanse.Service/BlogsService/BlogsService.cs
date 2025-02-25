using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.BlogsRepo;
using Gut_Cleanse.Repo.ProgramsRepo;
using Gut_Cleanse.Service.PaymentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.BlogsService
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepo _blogsRepo;
        public BlogsService(IBlogsRepo blogsRepo)
        {
            _blogsRepo = blogsRepo;
        }

        public IEnumerable<BlogModel> GetBlogs()
        {
            return _blogsRepo.GetBlogs();
        }

        public BlogModel GetBlogsById(int Id)
        {
            return _blogsRepo.GetBlogsById(Id);
        }
    }
}

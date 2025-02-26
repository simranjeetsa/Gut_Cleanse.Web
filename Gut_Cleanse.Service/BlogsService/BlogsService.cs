using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.BlogsRepo;

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

        public void AddBlog(BlogModel model)
        {
             _blogsRepo.AddBlog(model);
        }
    }
}

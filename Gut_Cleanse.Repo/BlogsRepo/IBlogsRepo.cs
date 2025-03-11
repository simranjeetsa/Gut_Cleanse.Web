using Gut_Cleanse.Model;

namespace Gut_Cleanse.Repo.BlogsRepo
{
    public interface IBlogsRepo 
    {
        IEnumerable<BlogModel> GetBlogs();
        BlogModel GetBlogsById(int Id);
        void AddBlog(BlogModel model);
        void DeleteBlog(int id);
    }
}

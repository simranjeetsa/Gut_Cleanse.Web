using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Repo.BlogsRepo
{
    public interface IBlogsRepo 
    {
        IEnumerable<BlogModel> GetBlogs();
        BlogModel GetBlogsById(int Id);
    }
}

using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.BlogsService
{
    public interface IBlogsService 
    {
        public IEnumerable<BlogModel> GetBlogs();
        public BlogModel GetBlogsById(int Id);

    }
}

using pertemuan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Service.BlogService
{
    public interface IBlogService
    {
        Task<List<Blog>> TampilSemuaBlog();
        Task<Blog> TampilkanBlogIdAsync(string id);
        Task<bool> BlogBaru(string username, Blog baru);
        Task<bool> UbahBlog(Blog datanya);
        Task<bool> HapusBlog(string id);
        Task<List<User>> TampilSemuaUser();
    }
}

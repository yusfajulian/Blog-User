using pertemuan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Repository.BlogRevository
{
    public interface IBlogRevository
    {
        Task<List<Blog>> TampilSemuaDataBlogAsync();
        Task<Blog> TampilkanBlogIdAsync(string id);
        Task<bool> BlogBaru(Blog baru);
        Task<bool> UbahBlog(Blog data);
        Task<User> CariUsername(string username);
        Task<Blog> CariBlog(string id);
        Task<bool> HapusBlog(Blog id);
        Task<List<User>> TampilSemuaDataUser();
    }
}

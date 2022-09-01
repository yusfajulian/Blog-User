using pertemuan1.Models;
using pertemuan1.Repository.BlogRevository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pertemuan1.Helper;
using Microsoft.AspNetCore.Http;

namespace pertemuan1.Service.BlogService
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRevository _blogRevo;
        private readonly FileService _file;
        public BlogService(IBlogRevository blogRevo, FileService file)
        {
            _blogRevo = blogRevo;
            _file = file;
        }

        // Tampil
        public async Task<Blog> TampilkanBlogIdAsync(string id)
        {
            return await _blogRevo.TampilkanBlogIdAsync(id);
        }

        public async Task<List<Blog>> TampilSemuaBlog()
        {
            return await _blogRevo.TampilSemuaDataBlogAsync();  
        }

        public async Task<List<User>> TampilSemuaUser()
        {
            return await _blogRevo.TampilSemuaDataUser();
        }

        public async Task<bool> BlogBaru(string username, Blog baru, IFormFile fotonya)
        {
            baru.Id = BuatPrimary.buatPrimary();
            baru.CreateDate = DateTime.Now;
            baru.User = await _blogRevo.CariUsername(username);
            baru.Image =await _file.SimpanFile(fotonya);
            //baru.Image = _file.SimpanFile(fotonya).result;

            return await _blogRevo.BlogBaru(baru);
        }

        public async Task<bool> UbahBlog(Blog datanya)
        {
            var cari = await _blogRevo.CariBlog(datanya.Id);

            cari.Title = datanya.Title;
            cari.Content = datanya.Content;
            cari.Status = datanya.Status; 

            return await _blogRevo.UbahBlog(cari);
        }   

        public async Task<bool> HapusBlog(string id)
        {
            var cari = await _blogRevo.CariBlog(id);

            return await _blogRevo.HapusBlog(cari);
        }
    }
}

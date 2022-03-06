using Microsoft.EntityFrameworkCore;
using pertemuan1.Data;
using pertemuan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Repository.BlogRevository
{
    public class BlogRevository : IBlogRevository
    {
        private readonly AppDbContext _BlogDb;
        public BlogRevository(AppDbContext Blogdb)
        {
            _BlogDb = Blogdb;
        }

        // Tambah
        public async Task<bool> BlogBaru(Blog baru)
        {
            _BlogDb.Tb_Blog.Add(baru);
            await _BlogDb.SaveChangesAsync();

            return true;
        }

        // Ubah 
        public async Task<bool> UbahBlog(Blog data)
        {
            _BlogDb.Tb_Blog.Update(data);
            await _BlogDb.SaveChangesAsync();

            return true;
        }

        // Menampilkan
        public async Task<Blog> TampilkanBlogIdAsync(string id)
        {
            return await _BlogDb.Tb_Blog.FirstOrDefaultAsync (x => x.Id == id);
        }

        public Task<List<Blog>> TampilSemuaDataBlogAsync()
        {
            var result = _BlogDb.Tb_Blog.Include(x => x.User).ToListAsync();

            return result;
        }

        public Task<List<User>> TampilSemuaDataUser()
        {
            var data = _BlogDb.Tb_User.Include(x => x.Roles).ToListAsync();

            return data;
        }

        // Hapus
        public async Task<bool> HapusBlog(Blog id)
        {
            _BlogDb.Remove(id);
            await _BlogDb.SaveChangesAsync();

            return true;
        }

        // Cari username
        public async Task<User> CariUsername(string username)
        {
            return await _BlogDb.Tb_User.FirstOrDefaultAsync(x => x.Username == username);
        }
        // Cari blog
        public async Task<Blog> CariBlog(string id)
        {
            return await _BlogDb.Tb_Blog.FirstOrDefaultAsync(x => x.Id == id);
        }

       
    }
}

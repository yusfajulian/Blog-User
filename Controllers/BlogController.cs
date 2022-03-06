using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pertemuan1.Models;
using pertemuan1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using pertemuan1.Helper;
using pertemuan1.Service.BlogService;

namespace pertemuan1.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blog;

        public BlogController(AppDbContext context, IBlogService blog)
        {
            _context = context;
            _blog = blog;
        }

        public async Task<IActionResult> Index()
        {
            var banyakData = new BlogDashBoard();

            banyakData.blog = await _blog.TampilSemuaBlog();
            banyakData.user = await _blog.TampilSemuaUser();
            //var data = _context.Tb_Blog.ToList(); // Untuk menampilkan data = select *from tb_blog;

            return View(banyakData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog parameter)
        {
            //if (ModelState.IsValid)
            //{
            //    parameter.Id = BuatPrimary.buatPrimary();   // bagian service
            //    string nama = User.GetUsername();       // bagian service
            //    parameter.User = _context.Tb_User.FirstOrDefault(x => x.Username == nama);  // bagian service
                
            //    // Proses masukan ke database
            //    _context.Add(parameter);    // bagian revositori
            //    _context.SaveChanges();     // bagian revositori
            //    await _context.SaveChangesAsync();

            //    // asalnya url https://localhost:5001/Blog/Create
            //    // menjadi https://localhost:5001/Home
            //    return Redirect("../Home");
            //}
            //return View(parameter);

            if (ModelState.IsValid)
            {
                string username = User.GetUsername().ToString();
                await _blog.BlogBaru(username, parameter);

                return RedirectToAction(controllerName: "Blog", actionName: "Index");
            }
            return View(parameter);
        }

        public async Task<IActionResult> Hapus(string id)
        {
            //var cari = _context.Tb_Blog.Where(x => x.Id == id).FirstOrDefault();

            //if (cari == null)
            //{
            //    return NotFound();
            //}

            //_context.Tb_Blog.Remove(cari);
            //await _context.SaveChangesAsync();
            //return RedirectToAction("Index");

            if (id == null)
            {
                return NotFound();
            }

            await _blog.HapusBlog(id);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Ubah(string id)
        {
            var cari = await _blog.TampilkanBlogIdAsync(id);
            
            if (cari == null)
            {
                return NotFound();
            }
            return View(cari);
        }

        [HttpPost]
        public async Task<IActionResult> Ubah(Blog data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _blog.UbahBlog(data);
                }
                catch
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
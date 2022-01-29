using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pertemuan1.Models;
using pertemuan1.Data;
using Microsoft.AspNetCore.Authorization;

namespace pertemuan1.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Tb_Blog.ToList(); // Untuk menampilkan data = select *from tb_blog;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog parameter)
        {
            if (ModelState.IsValid)
            {   
                // Proses masukan ke database
                _context.Add(parameter);
                _context.SaveChanges();
                await _context.SaveChangesAsync();

                // asalnya url https://localhost:5001/Blog/Create
                // menjadi https://localhost:5001/Home
                return Redirect("../Home");
            }
            return View(parameter);
        }
    }
}
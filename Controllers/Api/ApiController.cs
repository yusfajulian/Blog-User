using Microsoft.AspNetCore.Mvc;
using pertemuan1.Service.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Controllers.Api
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        private readonly IBlogService _blog;
        public ApiController(IBlogService s)
        {
            _blog = s;
        }

        [Route("blog")]
        public IActionResult Index()
        {
            var data = _blog.TampilSemuaBlog();
            
            return Ok(Helper.BanyakBantuan.Respon("Sukses", 200, "Berhasil menampilkan semua data blog", data));
        }

        [Route("blog/{id}")]
        public IActionResult blogId(string id)
        {
            var data = _blog.TampilkanBlogIdAsync(id);

            return Ok(Helper.BanyakBantuan.Respon("Sukses", 200, "Berhasil menampilkan data blog sesuai id nya", data));
        }

        [HttpPost]
        [Route("blog")]
        public IActionResult Tambah()
        {
            return Ok();
        }

        [HttpPut]
        [Route("blog/{id}")]
        public IActionResult Ubah()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("blog/{id}")]
        public IActionResult Hapus()
        {
            return Ok();
        }
    }
}

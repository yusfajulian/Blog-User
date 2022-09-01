using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pertemuan1.Models;
using pertemuan1.Service.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pertemuan1.Helper;

namespace pertemuan1.Controllers
{
    [Authorize]
    [Route("revo")]
    public class LayerController : Controller
    {
        private readonly IBlogService _blog;
        public LayerController(IBlogService blog)
        {
            _blog = blog;
        }
        [Route("semua")]
        public async Task<ActionResult<List<Blog>>> TampilSemuaBlog()
        {
            return View("Index", await _blog.TampilSemuaBlog());
        }

        [Route("buat")]
        public IActionResult BuatBlog()
        {
            return View();
        }

        [HttpPost]
        [Route("buat")]
        //public async Task<ActionResult<Blog>> BuatBlog(Blog data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string username = User.GetUsername().ToString();
        //        await _blog.BlogBaru(username, data);

        //        return RedirectToAction(controllerName: "Blog", actionName: "Index");
        //    }
        //    return View(data);
        //}

        [Route("Ubah")]
        public async Task<ActionResult<Blog>> UbahBlog(string id)
        {
            return View("Ubah", await _blog.TampilkanBlogIdAsync(id));
            //return View();
        }

        [HttpPost]
        [Route("Ubah")]
        public async Task<ActionResult<Blog>> UbahBlog(Blog data)
        {
            if (ModelState.IsValid)
            {
                await _blog.UbahBlog(data);

                return Redirect("detail/" + data.Id);
            }
            return View(data);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pertemuan1.Service.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IBlogService _service;

        public HomeController(IBlogService service)
        {
            _service = service;
        }
        
        public IActionResult Masuk()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();

        }
    }
}

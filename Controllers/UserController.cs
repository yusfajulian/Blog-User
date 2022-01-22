using Microsoft.AspNetCore.Mvc;
using pertemuan1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var read = _context.Tb_User.ToList();
            return View(read);
        }
    }
}

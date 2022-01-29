using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pertemuan1.Data;
using pertemuan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;

        public AkunController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DaftarAsync(User data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(data);
                _context.SaveChanges();
                await _context.SaveChangesAsync();

                //return RedirectToAction(controllerName: "Akun", actionName: "Masuk");
                return Redirect("Masuk");
            }
            return View(data);
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Masuk(User data)
        {
            //var cari = _context.Tb_User.Where( // proses pencarian
            //    bebas => 
            //    bebas.Username == data.Username 
            //    &&
            //    bebas.Password == data.Password
            //    ).FirstOrDefault(); // hanya dapat 1 data

            var username = _context.Tb_User.Where(bebas => bebas.Username == data.Username).FirstOrDefault();

            if (username != null)
            {
                var password = _context.Tb_User.Where(bebas => bebas.Username == data.Username && bebas.Password == data.Password).FirstOrDefault(); // hanya dapat 1 data
                if (password != null)
                {
                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }
                ViewBag.pesan = "Password Anda Salah";
                return View(data);
            }
            ViewBag.pesan="Username Anda Salah";
            return View(data);
        }
    }
}

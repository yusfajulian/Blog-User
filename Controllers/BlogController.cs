﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pertemuan1.Models;

namespace pertemuan1.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
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
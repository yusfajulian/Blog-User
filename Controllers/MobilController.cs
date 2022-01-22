using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pertemuan1.Models;

namespace pertemuan1.Controllers
{
    public class MobilController : Controller
    {

        public IActionResult Index()
        {
            //var mobils = new List<Models.Mobil>();
            //IEnumerable<Mobil> mobils2 = new List<Mobil>();

            //mobils.Add(new Mobil
            //{
            //    IDRegistrasi = 1,
            //    Tipe = "Verarri",
            //    Merek = "Toyota",
            //    Varian = "Apple",
            //});

            //mobils.Add(new Mobil
            //{
            //    IDRegistrasi = 2,
            //    Tipe = "Lambo",
            //    Merek = "Honda",
            //    Varian = "Android",
            //});

            //string nama = "Yusfa Julian";

            //ViewBag.namaSaya = nama;
            //ViewBag.mobils = mobils;
            //ViewData["nama"] = "Yusfaaa";

            //var banyakMobil = new Models.Mobil[]
            //{
            //    new Models.Mobil{ IDRegistrasi = 1, Tipe = "Sedan", Merek = "Toyota", Varian="FT86"},
            //    new Models.Mobil{ IDRegistrasi = 2, Tipe = "SUV", Merek = "Toyota", Varian="RAV4"},
            //    new Models.Mobil{ IDRegistrasi = 3, Tipe = "Sedan", Merek = "Honda", Varian="Accord"},
            //    new Models.Mobil{ IDRegistrasi = 4, Tipe = "SUV", Merek = "Honda", Varian="CRV"},
            //    new Models.Mobil{ IDRegistrasi = 5, Tipe = "Sedan", Merek = "Honda", Varian="City"},
            //};

            //var cariMobil = banyakMobil.Single(x => x.IDRegistrasi == 1);
            //var cariMobil = banyakMobil.Where(x => x.Tipe == "Sedan");

            //ViewBag.cari = cariMobil;
            // ViewBag.mobils = banyakMobil;
            //var tampil = banyakMobil.Where(x => x.IDRegistrasi == 1).FirstOrDefault();
            //ViewBag.mobils = tampil;

            //NO.1
            //var tampil = banyakMobil.Where(x => x.Merek == "Honda");
            //ViewBag.mobils = tampil;

            //NO.2
            //var tampil = banyakMobil.Where(x => x.Merek == "Honda" && x.Tipe == "Sedan");
            //ViewBag.mobils = tampil;

            //NO.3
            //var tampil =banyakMobil.Where(x=> x.Merek=="Honda" && x.Varian=="City").FirstOrDefault();
            //ViewBag.mobils = tampil;

            //NO.4
            //var tampil = banyakMobil.Where(x => x.Merek == "Toyota");
            //ViewBag.mobils = tampil;

            //NO.5
            //ViewBag.mobils = banyakMobil;

            return View();
        }
    }
}
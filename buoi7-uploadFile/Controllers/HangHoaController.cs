using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using buoi7_uploadFile.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace buoi7_uploadFile.Controllers
{
    public class HangHoaController : Controller
    {
        static List<HangHoa> dsHangHoa = new List<HangHoa>();
        public IActionResult Index()
        {
            return View(dsHangHoa);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hh, IFormFile Hinh) 
        {
            if (Hinh != null) 
            {
                var FileName = $"{DateTime.Now.Ticks}_{Hinh.FileName}";
                var fullpath = Path.Combine(Directory.GetCurrentDirectory()
                    ,"wwwroot", "hanghoa", FileName);
                hh.Hinh = FileName;
                using (var file = new FileStream(fullpath, FileMode.Create)) 
                {
                    Hinh.CopyTo(file);
                    dsHangHoa.Add(hh);
                    return Redirect("/HangHoa");
                }
            }
            return View();
        }
    }
}
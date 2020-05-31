using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using buoi7_uploadFile.Models;

namespace buoi7_uploadFile.Controllers
{
    public class HocVienController : Controller
    {
        public IActionResult ThongTin() 
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
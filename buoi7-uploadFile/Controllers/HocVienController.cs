using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using buoi7_uploadFile.Models;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace buoi7_uploadFile.Controllers
{
    public class HocVienController : Controller
    {
        public IActionResult DemoJson() 
        {
            var HV = new HocVien 
            {
                MaSo = 123123, TenHocVien = "Nguyen Van A", GioiTinh = true
                , SoDienThoai = "0909090900", DiemTrungBinh = 12
            };

            var data = new
            {
                HocVien = HV,
                TrungTam = "Nhat Nghe",
                NgayThanhLap = new DateTime(1234,12,12)
            };
            return Json(data);
        }
        public IActionResult ThongTin() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThongTin(HocVien HV, string Ghi)
        {
            if (Ghi == "Ghi File Text")
            {
                StreamWriter sw = new StreamWriter("HocVien.txt");
                sw.WriteLine(HV.MaSo);
                sw.WriteLine(HV.TenHocVien);
                sw.WriteLine(HV.SoDienThoai);
                sw.WriteLine(HV.DiemTrungBinh);
                sw.WriteLine(HV.GioiTinh);
                sw.Close();
            }
            else if (Ghi == "Ghi File Json") 
            {
                string chuoiJson = JsonConvert.SerializeObject(HV);
                System.IO.File.WriteAllText("HocVien.json", chuoiJson);
            }
            return View();
        }
        public IActionResult DocFileJson() 
        {
            var content = System.IO.File.ReadAllText("HocVien.Json");
            var hocvien = JsonConvert.DeserializeObject<HocVien>(content);
            return View("ThongTin", hocvien);
        }

        public IActionResult DocFileText() 
        {
            var content = System.IO.File.ReadAllLines("HocVien.txt");
            var hocvien = new HocVien
            {
                MaSo = int.Parse(content[0]),            
                TenHocVien = content[1],            
                SoDienThoai = content[2],            
                DiemTrungBinh = double.Parse(content[3]),            
                GioiTinh = content[4] == "true"? true : false            
            };
            return View("ThongTin", hocvien);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
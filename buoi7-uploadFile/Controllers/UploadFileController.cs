using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace buoi7_uploadFile.Controllers
{
    public class UploadFileController : Controller
    {
        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult UploadSingleFile(IFormFile Myfile) 
        {
            if (Myfile != null) 
            {
                var FileName = Path.Combine(Directory.GetCurrentDirectory()
                    , "wwwroot", "data",DateTime.Now.Ticks.ToString() + Myfile.FileName);
                //var file = new FileStream(FileName, FileMode.Create);
                //Myfile.CopyTo(file);
                //file.Close();

                using (var filestream = new FileStream(FileName, FileMode.Create)) 
                {
                    Myfile.CopyTo(filestream);
                }
            }
            return RedirectToAction("Upload", "UploadFile");
        }

        public IActionResult UploadMultipleFile(List<IFormFile> Myfile)
        {
            if (Myfile != null)
            {
                foreach (var file in Myfile) 
                {
                    var FileName = Path.Combine(Directory.GetCurrentDirectory()
                   , "documents", DateTime.Now.Ticks.ToString() + file.FileName);
                    using (var filestream = new FileStream(FileName, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                }
               
                //var file = new FileStream(FileName, FileMode.Create);
                //Myfile.CopyTo(file);
                //file.Close();

                
            }
            return RedirectToAction("Upload", "UploadFile");
        }
    }
}
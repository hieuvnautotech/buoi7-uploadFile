﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi7_uploadFile.Models
{
    public class HangHoa
    {

        public int MaHH { get; set; }
        public string TenHH { get; set; }
        public double DonGia { get; set; }
        public int GiamGia { get; set; }
        public string Hinh { get; set; }
        public double GiaBan => DonGia * (100 - GiamGia) / 100.0;

    }
}

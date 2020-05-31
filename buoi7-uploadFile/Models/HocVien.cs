using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace buoi7_uploadFile.Models
{
    public class HocVien
    {
        [DisplayName("Ma Hoc Vien")]
        public int MaSo { get; set; }
        [DisplayName("Ten Hoc Vien")]
        public string TenHocVien { get; set; }
        [DisplayName("So Dien Thoai")]
        public string SoDienThoai { get; set; }
        [DisplayName("Diem Trung Binh")]
        public double DiemTrungBinh { get; set; }
        [DisplayName("Gioi Tinh")]
        public bool GioiTinh { get; set; }
    }
}

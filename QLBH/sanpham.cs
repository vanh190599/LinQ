using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
    class sanpham
    {
        string maSP { get; set; }
        string tenSP { get; set; }
        string donGia { get; set; }
        string loaiSP { get; set; }

        public sanpham() { }
        public sanpham(string masp, string tensp, string dongia, string loaisp) {
            maSP = masp;
            tenSP = tensp;
            donGia= dongia;
            loaiSP = loaisp;
        }

    }
}

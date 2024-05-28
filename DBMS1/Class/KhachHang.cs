using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class KhachHang
    {
        private String maKH;
        private String maLoaiKhachHang;
        private String hoTen;
        private String soDT;

        public KhachHang(string maKH, string maLoaiKhachHang, string hoTen, string soDT)
        {
            this.MaKH = maKH;
            this.MaLoaiKhachHang = maLoaiKhachHang;
            this.HoTen = hoTen;
            this.SoDT = soDT;
        }

        public string MaKH { get => maKH; set => maKH = value; }
        public string MaLoaiKhachHang { get => maLoaiKhachHang; set => maLoaiKhachHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SoDT { get => soDT; set => soDT = value; }
    }
}

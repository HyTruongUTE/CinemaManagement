using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class BoPhim
    {
        private String maBP;
        private String tenBP;
        private String theLoai;
        private int thoiLuong;
        private String daoDien;
        private String dienVien;
        private String tomTat;

        public BoPhim(string maBP, string tenBP, string theLoai, int thoiLuong, string daoDien, string dienVien, string tomTat)
        {
            this.MaBP = maBP;
            this.TenBP = tenBP;
            this.TheLoai = theLoai;
            this.ThoiLuong = thoiLuong;
            this.DaoDien = daoDien;
            this.DienVien = dienVien;
            this.TomTat = tomTat;
        }

        public string MaBP { get => maBP; set => maBP = value; }
        public string TenBP { get => tenBP; set => tenBP = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public int ThoiLuong { get => thoiLuong; set => thoiLuong = value; }
        public string DaoDien { get => daoDien; set => daoDien = value; }
        public string DienVien { get => dienVien; set => dienVien = value; }
        public string TomTat { get => tomTat; set => tomTat = value; }
    }
}

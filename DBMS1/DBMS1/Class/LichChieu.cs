using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class LichChieu
    {
        private String maLC;
        private String maBP;
        private String maPC;
        private DateTime thoiGianChieu;
        private String trangThai;

        public LichChieu(string maLC, string maBP, string maPC, DateTime thoiGianChieu, string trangThai)
        {
            this.MaLC = maLC;
            this.MaBP = maBP;
            this.MaPC = maPC;
            this.ThoiGianChieu = thoiGianChieu;
            this.TrangThai = trangThai;
        }

        public string MaLC { get => maLC; set => maLC = value; }
        public string MaBP { get => maBP; set => maBP = value; }
        public string MaPC { get => maPC; set => maPC = value; }
        public DateTime ThoiGianChieu { get => thoiGianChieu; set => thoiGianChieu = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}

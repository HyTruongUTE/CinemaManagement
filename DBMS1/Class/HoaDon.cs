using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class HoaDon
    {
        private string maHD;
        private string maKH;
        private float triGiaHD;
        private DateTime ngayXuatHoaDon;

        public HoaDon(string maHD, string maKH, float triGiaHD, DateTime ngayXuatHoaDon)
        {
            this.MaHD = maHD;
            this.MaKH = maKH;
            this.TriGiaHD = triGiaHD;
            this.NgayXuatHoaDon = ngayXuatHoaDon;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public float TriGiaHD { get => triGiaHD; set => triGiaHD = value; }
        public DateTime NgayXuatHoaDon { get => ngayXuatHoaDon; set => ngayXuatHoaDon = value; }
    }
}

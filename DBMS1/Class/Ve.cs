using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class Ve
    {
        private String maVe;
        private float giaVe;
        private String maGheNgoi;
        private int thoiLuong;
        private DateTime ngayChieu;
        private DateTime gioChieu;
        private String maLoaiVe;

        public Ve(string maVe, float giaVe, string maGheNgoi, int thoiLuong, DateTime ngayChieu, DateTime gioChieu, string maLoaiVe)
        {
            this.MaVe = maVe;
            this.GiaVe = giaVe;
            this.MaGheNgoi = maGheNgoi;
            this.ThoiLuong = thoiLuong;
            this.NgayChieu = ngayChieu;
            this.GioChieu = gioChieu;
            this.MaLoaiVe = maLoaiVe;
        }

        public string MaVe { get => maVe; set => maVe = value; }
        public float GiaVe { get => giaVe; set => giaVe = value; }
        public string MaGheNgoi { get => maGheNgoi; set => maGheNgoi = value; }
        public int ThoiLuong { get => thoiLuong; set => thoiLuong = value; }
        public DateTime NgayChieu { get => ngayChieu; set => ngayChieu = value; }
        public DateTime GioChieu { get => gioChieu; set => gioChieu = value; }
        public string MaLoaiVe { get => maLoaiVe; set => maLoaiVe = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class LoaiKhachHang
    {
        private string maLoaiKH;
        private string tenLoaiKH;

        public LoaiKhachHang(string maLoaiKH, string tenLoaiKH)
        {
            this.MaLoaiKH = maLoaiKH;
            this.TenLoaiKH = tenLoaiKH;
        }

        public string MaLoaiKH { get => maLoaiKH; set => maLoaiKH = value; }
        public string TenLoaiKH { get => tenLoaiKH; set => tenLoaiKH = value; }
    }
}

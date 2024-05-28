using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1
{
    internal class PhongChieu
    {
        private String maPC;
        private String tenPC;
        private String trangThai;

        public PhongChieu(string maPC, string tenPC, string trangThai)
        {
            this.MaPC = maPC;
            this.TenPC = tenPC;
            this.TrangThai = trangThai;
        }

        public string MaPC { get => maPC; set => maPC = value; }
        public string TenPC { get => tenPC; set => tenPC = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class LoaiVe
    {
        private String maLV;
        private String tenLV;
        private String giaVe;

        public LoaiVe(string maLV, string tenLV, string giaVe)
        {
            this.MaLV = maLV;
            this.TenLV = tenLV;
            this.GiaVe = giaVe;
        }

        public string MaLV { get => maLV; set => maLV = value; }
        public string TenLV { get => tenLV; set => tenLV = value; }
        public string GiaVe { get => giaVe; set => giaVe = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class GheNgoi
    {
        private String maGN;
        private String maPC;
        private String khuVucGhe;
        private float giaGhe;
        private String trangThai;

        public GheNgoi(string maGN, string maPC, string khuVucGhe, float giaGhe, string trangThai)
        {
            this.MaGN = maGN;
            this.MaPC = maPC;
            this.KhuVucGhe = khuVucGhe;
            this.GiaGhe = giaGhe;
            this.TrangThai = trangThai;
        }

        public string MaGN { get => maGN; set => maGN = value; }
        public string MaPC { get => maPC; set => maPC = value; }
        public string KhuVucGhe { get => khuVucGhe; set => khuVucGhe = value; }
        public float GiaGhe { get => giaGhe; set => giaGhe = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}

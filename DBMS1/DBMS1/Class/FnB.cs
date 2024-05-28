using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class FnB
    {
        private String maFnB;
        private String tenFnB;
        private float giaFnB;
        private int sLKho;

        public FnB(string maFnB, string tenFnB, float giaFnB, int sLKho)
        {
            this.MaFnB = maFnB;
            this.TenFnB = tenFnB;
            this.GiaFnB = giaFnB;
            this.SLKho = sLKho;
        }

        public string MaFnB { get => maFnB; set => maFnB = value; }
        public string TenFnB { get => tenFnB; set => tenFnB = value; }
        public float GiaFnB { get => giaFnB; set => giaFnB = value; }
        public int SLKho { get => sLKho; set => sLKho = value; }
    }
}

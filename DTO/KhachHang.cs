using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    class KhachHang
    {
        public KhachHang(string makh, string tenkh, string sdt)
        {
            Makh = makh;
            Tenkh = tenkh;
            Sdt = sdt;
        }

        public KhachHang(DataRow row)
        {
            Makh = row["makh"].ToString();
            Tenkh = row["tenkh"].ToString();
            Sdt = row["sdt"].ToString();
        }
        private string makh;
        private string tenkh;
        private string sdt;

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}

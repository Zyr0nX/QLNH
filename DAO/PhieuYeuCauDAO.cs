using QuanLyKhachHang.DTO;
using System.Data;

namespace QuanLyKhachHang.DAO
{
    public class PhieuYeuCauDAO
    {
        private static PhieuYeuCauDAO instance;

        internal static PhieuYeuCauDAO Instance
        {
            get { if (instance == null) instance = new PhieuYeuCauDAO(); return instance; }
            private set { instance = value; }
        }

        private PhieuYeuCauDAO() { }

        public string getPycByMabanChuaThanhToan(string maban)
        {
            DataTable data = DataProvider.Instance.executeQuery("select * from BANAN where MABAN = '"+maban+"' and MAPYC is not null");
            if(data.Rows.Count > 0)
            {
                Table table = new Table(data.Rows[0]);
                return table.Mapyc;
            }
            return "-1";
        }
        public void insertPYC(string username,string maban)
        {
            DataProvider.Instance.executeNonQuery("exec ThemPYC @username , @maban", new object[] { username,  maban});
        }
        public string getMaxPYC()
        {
            return DataProvider.Instance.executeScalar("select max(mapyc) from phieuyeucau").ToString();
        }
    }
}

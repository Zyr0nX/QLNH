using System.Data;

namespace QuanLyKhachHang.DAO
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;

        internal static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }

        private KhachHangDAO() { }

        public string getTenKHbyMaKH(string makh)
        {
            string data = DataProvider.Instance.executeScalar("select TENKH from KHACHHANG where MAKH = '" + makh + "'").ToString();
            return data;
        }
        public DataTable getKHList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from KHACHHANG");
            return table;
        }
    }
}

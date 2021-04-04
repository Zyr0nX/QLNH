using System.Data;

namespace QuanLyKhachHang.DAO
{
    class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        internal static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            private set { instance = value; }
        }

        private NhaCungCapDAO() { }

        public string getTenNCCbyMaNCC(string mancc)
        {
            string data = DataProvider.Instance.executeScalar("select TENNCC from NHACUNGCAP where MANCC = '" + mancc + "'").ToString();
            return data;
        }
        public DataTable getNCCList()
        {
            DataTable table = DataProvider.Instance.executeQuery("select * from NHACUNGCAP");
            return table;
        }
    }
}

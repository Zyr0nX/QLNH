using System;
using System.Windows.Forms;
using QuanLyKhachHang.DAO;

namespace QuanLyKhachHang.GUI.UserControls.DoiTac
{
    public partial class UC_DoiTacNew : UserControl
    {
        public UC_DoiTacNew()
        {
            InitializeComponent();
            loadKH();
        }
        private void btnKhach_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(0);
            clearAllBindings();
            loadKH();
        }
        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            pageDoiTac.SelectTab(1);
            clearAllBindings();
            loadNCC();
        }
        void clearAllBindings()
        {
            ClearAllBindingsNCC();
            ClearAllBindingsKH();
            choiceKH = -1;
            choiceNCC = -1;
        }

        #region KhachHang
        private int choiceKH = -1;
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            btnLuuKH.Visible = true;
            btnHuyKH.Visible = true;
            choiceKH = 0;
        }
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            btnLuuKH.Visible = true;
            btnHuyKH.Visible = true;
            choiceKH = 1;
        }
        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            btnLuuKH.Visible = true;
            btnHuyKH.Visible = true;
            choiceKH = 2;
        }
        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            switch (choiceKH)
            {
                case 0:
                    //ThemKH();
                    break;
                case 1:
                    //SuaKH();
                    break;
                case 2:
                    //XoaKH
                    break;
                default:
                    break;
            }
            btnLuuKH.Visible = false;
            btnHuyKH.Visible = false;
            choiceKH = -1;
        }
        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            btnLuuKH.Visible = false;
            btnHuyKH.Visible = false;
            choiceKH = -1;
        }
        void loadKH()
        {
            LoadKHList();
            KHBinding();
        }
        private void LoadKHList()
        {
            dtgrKH.DataSource = KhachHangDAO.Instance.getKHList();
        }
        void KHBinding()
        {
            txtMaKH.DataBindings.Add(new Binding("text", dtgrKH.DataSource, "MaKH"));
            txtTenKH.DataBindings.Add(new Binding("text", dtgrKH.DataSource, "TenKH"));
            txtSDTKH.DataBindings.Add(new Binding("text", dtgrKH.DataSource, "SDT"));
        }
        void ClearAllBindingsKH()
        {
            foreach (Control c in grbChinhSuaKH.Controls)
                c.DataBindings.Clear();
        }
        #endregion

        #region NhaCungCap
        private int choiceNCC = -1;
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            btnLuuNCC.Visible = true;
            btnHuyNCC.Visible = true;
            choiceNCC = 0;
        }
        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            btnLuuNCC.Visible = true;
            btnHuyNCC.Visible = true;
            choiceNCC = 1;
        }
        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            btnLuuNCC.Visible = true;
            btnHuyNCC.Visible = true;
            choiceNCC = 2;
        }
        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            switch (choiceNCC)
            {
                case 0:
                    //ThemNCC();
                    break;
                case 1:
                    //SuaNCC();
                    break;
                case 2:
                    //XoaNCC
                    break;
                default:
                    break;
            }
        }
        private void btnHuyNCC_Click(object sender, EventArgs e)
        {
            btnLuuNCC.Visible = false;
            btnHuyNCC.Visible = false;
            choiceNCC = -1;
        }
        void loadNCC()
        {
            LoadNCCList();
            NCCBinding();
        }
        private void LoadNCCList()
        {
            dtgrNCC.DataSource = NhaCungCapDAO.Instance.getNCCList();
        }
        void NCCBinding()
        {
            txtMaNCC.DataBindings.Add(new Binding("text", dtgrNCC.DataSource, "MaNCC"));
            txtTenNCC.DataBindings.Add(new Binding("text", dtgrNCC.DataSource, "TenNCC"));
            txtSDTNCC.DataBindings.Add(new Binding("text", dtgrNCC.DataSource, "SDT"));
            txtDiaChiNCC.DataBindings.Add(new Binding("text", dtgrNCC.DataSource, "DiaChi"));
        }
        void ClearAllBindingsNCC()
        {
            foreach (Control c in grbChinhSuaNCC.Controls)
                c.DataBindings.Clear();
        }
        #endregion
    }
}

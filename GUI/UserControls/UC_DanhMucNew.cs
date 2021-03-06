using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyKhachHang.DAO;
using QuanLyKhachHang.DTO;

namespace QuanLyKhachHang.GUI.UserControls.DanhMuc
{
    public partial class UC_DanhMucNew : UserControl
    {
        public UC_DanhMucNew()
        {
            InitializeComponent();
            loadMonAn();
        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(0);
            clearAllBindings();
            loadMonAn();
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(1);
            clearAllBindings();
            loadLoaiMon();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(2);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(3);
            bunifuCustomDataGridBanAn.DataSource = (new BanAnDAO()).GetListBanAn();
            Load_BanAN();
            MacDinhBanAn();
        }

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            pageDanhMuc.SelectTab(4);
            bunifuCustomDataGridNL.DataSource = (new NguyenLieuDAO()).GetListNguyenLieu();
            Load_NL();
            MacDinhNL();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            using (Add_NhanVien f = new Add_NhanVien())
                f.ShowDialog();
        }

        void clearAllBindings()
        {
            ClearAllBindingsLoaiMon();
            ClearAllBindingsMonAn();
        }

        #region Món ăn
        void loadMonAn()
        {
            loadMonAnList();
            monAnBinding();
            loadLoaiMonComboBox();
            
            
        }
        void loadMonAnList()
        {
            dtgvMonAn.DataSource = MonAnDAO.Instance.getMonAnList();
        }

        void loadLoaiMonComboBox()
        {
            List<LoaiMon> list = LoaiMonDAO.Instance.getListLoaiMon();
            cbbLoaiMon.DataSource = list;
            cbbLoaiMon.DisplayMember = "Tenlm";

        }

        void monAnBinding()
        {
            txtMaMon.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "mama"));
            txtTenMon.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "tenmonan"));
            txtDVT.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "dvt"));
            txtDonGia.DataBindings.Add(new Binding("text", dtgvMonAn.DataSource, "dongia"));
            cbbLoaiMon.DataBindings.Add(new Binding("Text", dtgvMonAn.DataSource, "Maloai"));
        }
        void ClearAllBindingsMonAn()
        {
            foreach (Control c in grbChinhSuaMon.Controls)
                c.DataBindings.Clear();
        }
        #endregion


        #region Loại món

        void loadLoaiMon()
        {
            loadLoaiMonList();
            loaiMonBinding();
            
        }
        void loadLoaiMonList()
        {
            dtgvLoaiMon.DataSource = LoaiMonDAO.Instance.getListLoaiMon();
        }
        void loaiMonBinding()
        {
            txtMaLoaiMon.DataBindings.Add(new Binding("Text", dtgvLoaiMon.DataSource, "Malm"));
            txtTenLoaiMon.DataBindings.Add(new Binding("text", dtgvLoaiMon.DataSource, "Tenlm"));
        }
        void ClearAllBindingsLoaiMon()
        {
            foreach (Control c in grbChinhSuaLoai.Controls)
                c.DataBindings.Clear();
        }
        #endregion


        #region Nhân viên

        #endregion


        #region Bàn ăn
        readonly BanAnDTO bandto = new BanAnDTO();
        readonly BanAnDAO bandao = new BanAnDAO();
        public void MacDinhBanAn()
        {
            bunifuTextBoxmabanan.Enabled = false;
            bunifuTextBoxsochongoi.Enabled = false;

            BtnThemBanAn.Enabled = true;
            BtnSuaBanAn.Enabled = true;
            BtnXoaBanAn.Enabled = true;
            BtnLuuBanAn.Enabled = false;
            BtnHuyBanAn.Enabled = false;
        }
        public void SuaBanAn()
        {
            bunifuTextBoxsochongoi.Enabled = true;
            bunifuTextBoxmabanan.Enabled = true;

            BtnThemBanAn.Enabled = false;
            BtnSuaBanAn.Enabled = true;
            BtnXoaBanAn.Enabled = false;
            BtnLuuBanAn.Enabled = true;
            BtnHuyBanAn.Enabled = true;
        }

        private void Load_BanAN()
        {

            bunifuCustomDataGridBanAn.Columns["MABAN"].HeaderText = "Mã Bàn Ăn";
            bunifuCustomDataGridBanAn.Columns["SOCHONGOI"].HeaderText = "Số Ngồi Tối Đa";
            bunifuCustomDataGridBanAn.Columns["MAPYC"].HeaderText = "Mã Phiếu Yêu Cầu";
            bunifuCustomDataGridBanAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //bunifuCustomDataGridBanAn.Columns["MABANAN"].Width = 100;
            //bunifuCustomDataGridBanAn.Columns["SOCHONGOI"].Width = 200;
            //bunifuCustomDataGridBanAn.Columns["MAPYC"].Width = 200;
            bunifuCustomDataGridBanAn.DataSource = bandao.GetListBanAn();
        }
        public bool CheckThemBA()
        {

            if (bunifuTextBoxmabanan.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập số bàn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxmabanan.Focus();
                return false;
            }

            if (bunifuTextBoxsochongoi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập số chỗ ngồi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxsochongoi.Focus();
                return false;
            }
            return true;
        }
        public void Load_Lai_BanAn()
        {
            bunifuCustomDataGridBanAn.DataSource = (bandao.GetListBanAn());
        }


        private void BunifuCustomDataGridBanAn_SelectionChanged(object sender, EventArgs e)
        {
            int index = bunifuCustomDataGridBanAn.CurrentCell == null ? -1 : bunifuCustomDataGridBanAn.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxmabanan.Text = bunifuCustomDataGridBanAn.Rows[bunifuCustomDataGridBanAn.CurrentRow.Index].Cells[0].Value.ToString().Trim();
                bunifuTextBoxsochongoi.Text = bunifuCustomDataGridBanAn.Rows[bunifuCustomDataGridBanAn.CurrentRow.Index].Cells[2].Value.ToString().Trim();
            }
        }
        private void BtnThemBanAn_Click(object sender, EventArgs e)
        {

            Add_BanAn BanAn = new Add_BanAn();
            BanAn.ShowDialog();
            Load_Lai_BanAn();
        }
        private void BtnSuaBanAn_Click(object sender, EventArgs e)
        {
            SuaBanAn();
        }
        private void BunifuButtonLuuBanAn_Click(object sender, EventArgs e)
        {
            MacDinhBanAn();
            if (CheckThemBA())
            {
                bandto.MABAN = bunifuTextBoxmabanan.Text.ToString().Trim();
                bandto.SOCHONGOI = int.Parse(bunifuTextBoxsochongoi.Text.ToString().Trim());
                bandto.MAPYC = "";
                bool suaban = bandao.Update_ban(bandto);
                if (suaban == true)
                {
                    DialogResult result = MessageBox.Show("Thành công", "Chỉnh sửa", MessageBoxButtons.OK);
                    Load_Lai_BanAn();
                }
            }
        }
        private void BtnXoaBanAn_Click(object sender, EventArgs e)
        {
            bandto.MABAN = bunifuTextBoxmabanan.Text.ToString().Trim();
            bandto.SOCHONGOI = int.Parse(bunifuTextBoxsochongoi.Text.ToString().Trim());
            DialogResult x = MessageBox.Show("Xóa", "Bạn có chắc chắn muốn xóa bàn số " + bandto.MABAN + " chứ ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);  
            bool xoaban = bandao.XoaBA(bandto);
            if(xoaban == true && x == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show("Thành công", "Xóa", MessageBoxButtons.OK);
                Load_Lai_BanAn();
            }    

        }

        private void BtnHuyBanAn_Click(object sender, EventArgs e)
        {
            Load_Lai_BanAn();
            MacDinhBanAn();
        }
        #endregion

        #region Nguyên liệu
        readonly NguyenLieuDAO NLdao = new NguyenLieuDAO();
        readonly NguyenLieuDTO NLdto = new NguyenLieuDTO();
        string luu = "";
        public void MacDinhNL()
        {
            BtnThemNguyenLieu.Text = "Thêm";
            bunifuTextBoxMaNL.Enabled = false;
            bunifuTextBoxTenNL.Enabled = false;
            bunifuTextBoxDVT.Enabled = false;
            bunifuTextBoxDonGia.Enabled = false;

            BtnThemNguyenLieu.Enabled = true;
            BtnSuaNguyenLieu.Enabled = true;
            BtnXoaNguyenLieu.Enabled = true;
            BtnLuuNguyenLieu.Enabled = false;
            BtnHuyNguyenLieu.Enabled = false;
        }
        public void SuaNL()
        {
            BtnThemNguyenLieu.Text = "Thêm";
            bunifuTextBoxMaNL.Enabled = true;
            bunifuTextBoxTenNL.Enabled = true;
            bunifuTextBoxDVT.Enabled = true;
            bunifuTextBoxDonGia.Enabled = true;

            BtnThemNguyenLieu.Enabled = false;
            BtnSuaNguyenLieu.Enabled = true;
            BtnXoaNguyenLieu.Enabled = false;
            BtnLuuNguyenLieu.Enabled = true;
            BtnHuyNguyenLieu.Enabled = true;
        }
        public void ThemNL()
        {
            bunifuTextBoxMaNL.Text = "";
            bunifuTextBoxTenNL.Text = "";
            bunifuTextBoxDVT.Text = "";
            bunifuTextBoxDonGia.Text = "";
            bunifuTextBoxMaNL.Enabled = true;
            bunifuTextBoxTenNL.Enabled = true;
            bunifuTextBoxDVT.Enabled = true;
            bunifuTextBoxDonGia.Enabled = true;

            BtnThemNguyenLieu.Enabled = true;
            BtnThemNguyenLieu.Text = "Làm Mới";
            BtnSuaNguyenLieu.Enabled = false;
            BtnXoaNguyenLieu.Enabled = false;
            BtnLuuNguyenLieu.Enabled = true;
            BtnHuyNguyenLieu.Enabled = true;

        }
        public void Load_NL()
        {
            bunifuCustomDataGridNL.Columns["MANL"].HeaderText = "Mã Nguyên Liệu";
            bunifuCustomDataGridNL.Columns["TENNL"].HeaderText = "Tên Nguyên Liệu";
            bunifuCustomDataGridNL.Columns["DVT"].HeaderText = "Đơn Vị Tính";
            bunifuCustomDataGridNL.Columns["DONGIA"].HeaderText = "Đơn Giá";
            bunifuCustomDataGridNL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bunifuCustomDataGridNL.DataSource = NLdao.GetListNguyenLieu();
        }
        public void Load_lai_NL()
        {
            bunifuCustomDataGridNL.DataSource = NLdao.GetListNguyenLieu();
        }
        public bool CheckThemNL()
        {

            if (bunifuTextBoxMaNL.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập mã nguyên liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxMaNL.Focus();
                return false;
            }

            if (bunifuTextBoxTenNL.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập tên nguyên liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxTenNL.Focus();
                return false;
            }
            if (bunifuTextBoxDVT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập đơn vị tính!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxDVT.Focus();
                return false;
            }
            if (bunifuTextBoxDonGia.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lỗi", "Bạn chưa nhập đơn giá!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBoxDonGia.Focus();
                return false;
            }
            return true;
        }
        private void BtnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            ThemNL();
            luu = "them";
        }
        private void BtnSuaNguyenLieu_Click(object sender, EventArgs e)
        {
            SuaNL();
            luu = "sua";
        }

        private void BtnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            NLdto.MANL = bunifuTextBoxMaNL.Text;
            NLdto.TENNL = bunifuTextBoxTenNL.Text;
            NLdto.DVT = bunifuTextBoxDVT.Text;
            NLdto.DONGIA = int.Parse(bunifuTextBoxDonGia.Text);
            DialogResult xoa = MessageBox.Show("Xóa", "Bạn chắc chắn muốn xóa nguyên liệu "+ NLdto.TENNL+ " chứ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            bool xoanl = NLdao.XoaNL(NLdto);
            if(xoanl == true && xoa == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show("Thành công", "Xóa", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Load_lai_NL();
                    MacDinhNL();
                }
            }    
        }

        private void BtnLuuNguyenLieu_Click(object sender, EventArgs e)
        {
           
            if (CheckThemNL() && luu == "them")
            {
                NLdto.MANL = bunifuTextBoxMaNL.Text;
                NLdto.TENNL = bunifuTextBoxTenNL.Text;
                NLdto.DVT = bunifuTextBoxDVT.Text;
                NLdto.DONGIA = int.Parse(bunifuTextBoxDonGia.Text);
                bool themnl = NLdao.ThemNL(NLdto);
                if ( themnl == true)
                {

                    DialogResult result = MessageBox.Show("Thành công", "Thêm", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        Load_lai_NL();
                        MacDinhNL();
                    }
                }
            }
            if (CheckThemNL() && luu == "sua")
            {
                NLdto.MANL = bunifuTextBoxMaNL.Text;
                NLdto.TENNL = bunifuTextBoxTenNL.Text;
                NLdto.DVT = bunifuTextBoxDVT.Text;
                NLdto.DONGIA = int.Parse(bunifuTextBoxDonGia.Text);
                bool suanl = NLdao.Update_NL(NLdto);
                if (suanl == true)
                {
                    DialogResult result = MessageBox.Show("Thành công", "Chỉnh sửa", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        Load_lai_NL();
                        MacDinhNL();
                    }
                }
            }

        }

        private void BtnHuyNguyenLieu_Click(object sender, EventArgs e)
        {
            MacDinhNL();
            Load_lai_NL();
        }

        private void BunifuCustomDataGridNL_SelectionChanged(object sender, EventArgs e)
        {
            int index = bunifuCustomDataGridNL.CurrentCell == null ? -1 : bunifuCustomDataGridNL.CurrentCell.RowIndex;
            if (index != -1)
            {
                bunifuTextBoxMaNL.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[0].Value.ToString().Trim();
                bunifuTextBoxTenNL.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                bunifuTextBoxDVT.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[2].Value.ToString().Trim();
                bunifuTextBoxDonGia.Text = bunifuCustomDataGridNL.Rows[bunifuCustomDataGridNL.CurrentRow.Index].Cells[3].Value.ToString().Trim();
            }
        }


        #endregion
    }
}

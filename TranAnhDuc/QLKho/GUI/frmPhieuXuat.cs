using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKho.BLL;
using QLKho.Entity;
using System.Data.SqlClient;


namespace QLKho.GUI
{
    public partial class frmPhieuXuat : Form
    {
        BindingSource PhieuXuat = new BindingSource();
        BindingSource ChiTietPhieuXuat = new BindingSource();
        PhieuXuatBLL PhieuXuatBLL = new PhieuXuatBLL();
        //KhoBLL Kho = new KhoBLL();
        ChiTiet_PhieuXuatBLL ctphieuxuatBLL = new ChiTiet_PhieuXuatBLL();
        NhanVienBLL nhanvien = new NhanVienBLL();
        private string MaPX;
        public frmPhieuXuat()
        {
            InitializeComponent();
            LoadPhieuXuat();
        }
        void LoadPhieuXuat()
        {
            Clear_Binding();
            dtgPhieuXuat.DataSource = PhieuXuat;
            PhieuXuat.DataSource = PhieuXuatBLL.PhieuXuat_Select();
            dtgPhieuXuat.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            Binding();
            dtgPhieuXuat.Refresh();
        }
        void LoadChiTietPhieuXuat()
        {
            Clear_Binding_ChiTiet();
            int MaPX = Convert.ToInt32 (txtMaPX.Text);;
            //string MaKHo = txtMakho.Text;
            lbMaPX.Text =Convert.ToString (MaPX);
            //lbMaKho.Text = MaKHo;
            PhieuXuat phieuxuat = new PhieuXuat(MaPX, "", -1);
            dtgChiTietPhieuXuat.DataSource = ChiTietPhieuXuat;
            ChiTietPhieuXuat.DataSource = PhieuXuatBLL.ChiTietPhieuXuat_Select(phieuxuat);
            dtgChiTietPhieuXuat.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            Binding_ChiTiet();
            dtgChiTietPhieuXuat.Refresh();
        }
        void Binding()
        {
            txtMaPX.DataBindings.Add(new Binding("Text", dtgPhieuXuat.DataSource, "Mã phiếu xuất", true, DataSourceUpdateMode.Never));
            dtpNgayXuat.DataBindings.Add(new Binding("Value", dtgPhieuXuat.DataSource, "Ngày xuất", true, DataSourceUpdateMode.Never));
            //txtMakho.DataBindings.Add(new Binding("Text", dtgPhieuXuat.DataSource, "Mã kho", true, DataSourceUpdateMode.Never));
            txtMaNV.DataBindings.Add(new Binding("Text", dtgPhieuXuat.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding()
        {
            txtMaPX.DataBindings.Clear();
            dtpNgayXuat.DataBindings.Clear();
            //txtMakho.DataBindings.Clear();
            txtMaNV.DataBindings.Clear();
        }
        void Binding_ChiTiet()
        {
            txtMaMH.DataBindings.Add(new Binding("Text", dtgChiTietPhieuXuat.DataSource, "Mã mặt hàng", true, DataSourceUpdateMode.Never));
            txtDVT.DataBindings.Add(new Binding("Text", dtgChiTietPhieuXuat.DataSource, "Đơn vị tính", true, DataSourceUpdateMode.Never));
            txtTenMH.DataBindings.Add(new Binding("Text", dtgChiTietPhieuXuat.DataSource, "Tên mặt hàng", true, DataSourceUpdateMode.Never));
            txtMaLo.DataBindings.Add(new Binding("Text", dtgChiTietPhieuXuat.DataSource, "Mã lô", true, DataSourceUpdateMode.Never));
            txtSLXuat.DataBindings.Add(new Binding("Text", dtgChiTietPhieuXuat.DataSource, "Số lượng xuất", true, DataSourceUpdateMode.Never));
            txtDonGiaXuat.DataBindings.Add(new Binding("Text", dtgChiTietPhieuXuat.DataSource, "Đơn giá xuất", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding_ChiTiet()
        {
            txtMaMH.DataBindings.Clear();
            txtDVT.DataBindings.Clear();
            txtTenMH.DataBindings.Clear();
            txtMaLo.DataBindings.Clear();
            txtSLXuat.DataBindings.Clear();
            txtDonGiaXuat.DataBindings.Clear();
        }
        private void btnXemChiTietPX_Click(object sender, EventArgs e)
        {
            btnThemCTPX.Enabled = true;
            btnSuaCTPX.Enabled = true;
            btnXoaCTPX.Enabled = true;
            btnTimKiemChiTiet.Enabled = true;
            btnReport.Enabled = true;
            LoadChiTietPhieuXuat();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int MaNV = Convert.ToInt32(txtMaNV.Text);
            string NgayXuat = dtpNgayXuat.Value.ToString("MM/dd/yyyy");
            PhieuXuat px = new PhieuXuat(-1,NgayXuat,MaNV);
            PhieuXuatBLL.PhieuXuat_Insert(px);
            LoadPhieuXuat();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            string NgayXuat = dtpNgayXuat.Value.ToString("MM/dd/yyyy");
            //string MaKho = txtMakho.Text;
            int MaNV = Convert.ToInt32(txtMaNV.Text);
            //KhoHang kho = new KhoHang(MaKho, "", "");
            NhanVien NV = new NhanVien(MaNV, "", "");
            PhieuXuat phieuxuat = new PhieuXuat(MaPX, NgayXuat, MaNV);
            PhieuXuatBLL.PhieuXuat_Update(phieuxuat);
            LoadPhieuXuat();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            PhieuXuat phieuxuat = new PhieuXuat(MaPX,"",-1);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (PhieuXuatBLL.PhieuXuat_Delete(phieuxuat))
                    LoadPhieuXuat();
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TuKhoa = txtTimKiem.Text;
            dtgPhieuXuat.DataSource = PhieuXuat;
            PhieuXuat.DataSource = PhieuXuatBLL.PhieuXuat_TimKiem(TuKhoa);
        }

        //private void txtMaMH_TextChanged(object sender, EventArgs e)
        //{
        //    string MaMH = txtMaMH.Text;
        //    string MaLo = txtMaLo.Text;
        //   string MaPX = lbMaPX.Text;
        //    MatHang mathang = new MatHang(MaMH, "");
        //    PhieuXuatBLL.TenMH(mathang);
        //    txtTenMH.DataBindings.Clear();
        //    txtTenMH.DataBindings.Add("Text", PhieuXuatBLL.TenMH(mathang), "Tên mặt hàng");
        //    ChiTiet_PhieuXuat ctphieuxuat = new ChiTiet_PhieuXuat(MaPX, MaMH, MaLo, -1);
        //    if (ctphieuxuatBLL.CheckMaCTPhieuXuat(ctphieuxuat))
        //    {
        //        btnThemCTPX.Enabled = false;
        //        btnSuaCTPX.Enabled = true;
        //        btnXoaCTPX.Enabled = true;
        //        btnReport.Enabled = true;
        //    }
        //    else
        //    {
        //        btnThemCTPX.Enabled = true;
        //        btnSuaCTPX.Enabled = false;
        //        btnXoaCTPX.Enabled = false;
        //        btnReport.Enabled = false;
        //    }
        //}
        void ChiTietPX_Load()
        {
            Clear_Binding_ChiTiet();
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            
            ChiTiet_PhieuXuat ctphieuxuat = new ChiTiet_PhieuXuat(MaPX,"",-1,-1,-1);
            dtgChiTietPhieuXuat.DataSource = ChiTietPhieuXuat;
            ChiTietPhieuXuat.DataSource = ctphieuxuatBLL.ChittietPhieuxuat_Load(ctphieuxuat);
            Binding_ChiTiet();
            dtgChiTietPhieuXuat.Refresh();
        }
        private void btnThemCTPX_Click(object sender, EventArgs e)
        {
            string DVT =  txtDVT.Text;
            int MaLo = Convert.ToInt32 (txtMaLo.Text);
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            int SLXuat = Convert.ToInt32(txtSLXuat.Text);
            int DonGiaXuat = Convert.ToInt32(txtDonGiaXuat.Text);
            ChiTiet_PhieuXuat ctphieuxuat = new ChiTiet_PhieuXuat(MaPX, DVT, MaLo, SLXuat, DonGiaXuat);
            if(ctphieuxuatBLL.ChiTietPhieuXuat_Insert(ctphieuxuat)==true)
                ChiTietPX_Load();
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void btnSuaCTPX_Click(object sender, EventArgs e)
        {
            string DVT = txtDVT.Text;
            int MaLo = Convert.ToInt32 (txtMaLo.Text);
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            int SLXuat = Convert.ToInt32(txtSLXuat.Text);
            int DonGiaXuat = Convert.ToInt32(txtDonGiaXuat.Text);
            ChiTiet_PhieuXuat ctphieuxuat = new ChiTiet_PhieuXuat(MaPX, DVT, MaLo, SLXuat  ,DonGiaXuat);
            if (ctphieuxuatBLL.ChittietPhieuxuat_Update(ctphieuxuat))
                ChiTietPX_Load();
            else
                MessageBox.Show("Chỉnh sửa thất bại");
        }

        private void btnXoaCTPX_Click(object sender, EventArgs e)
        {
            string DVT = txtDVT.Text;
            int MaLo = Convert.ToInt32 (txtMaLo.Text);
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            int SLXuat = Convert.ToInt32(txtSLXuat.Text);
            int DonGiaXuat = Convert.ToInt32(txtDonGiaXuat.Text);
            ChiTiet_PhieuXuat ctphieuxuat = new ChiTiet_PhieuXuat(MaPX, DVT, MaLo, SLXuat,  DonGiaXuat);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (ctphieuxuatBLL.ChittietPhieuxuat_Delete(ctphieuxuat))
                    ChiTietPX_Load();
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void txtMaPX_TextChanged(object sender, EventArgs e)
        {
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            PhieuXuat phieuxuat = new PhieuXuat(MaPX, "", -1);
            //if (PhieuXuatBLL.CheckMaPhieuXuat(phieuxuat))
            //{
            //    btnThem.Enabled = false;
            //    dtpNgayXuat.Enabled = true;
            //    btnSua.Enabled = true;
            //    btnXoa.Enabled = true;
            //    btnXemChiTietPX.Enabled = true;
            //}
            //else
            //{
            //    btnThem.Enabled = true;
            //    dtpNgayXuat.Enabled = false;
            //    btnSua.Enabled = false;
            //    btnXoa.Enabled = false;
            //    btnXemChiTietPX.Enabled = false;
            //}
        }

        //private void txtMaLo_TextChanged(object sender, EventArgs e)
        //{
        //    string MaMH = txtMaMH.Text;
        //    string MaLo = txtMaLo.Text;
        //    string MaPX = lbMaPX.Text;
        //    ChiTiet_PhieuXuat ctphieuxuat = new ChiTiet_PhieuXuat(MaPX, MaMH, MaLo, -1);
        //    if (ctphieuxuatBLL.CheckMaCTPhieuXuat(ctphieuxuat))
        //    {
        //        btnThemCTPX.Enabled = false;
        //        btnSuaCTPX.Enabled = true;
        //        btnXoaCTPX.Enabled = true;
        //        btnReport.Enabled = true;
        //    }
        //    else
        //    {
        //        btnThemCTPX.Enabled = true;
        //        btnSuaCTPX.Enabled = false;
        //        btnXoaCTPX.Enabled = false;
        //        btnReport.Enabled = false;
        //    }
        //}

        private void btnTimKiemChiTiet_Click(object sender, EventArgs e)
        {
            string TuKhoa = txtTimKiemChiTiet.Text;
            int MaPX = Convert.ToInt32 (txtMaPX.Text);
            dtgChiTietPhieuXuat.DataSource = ChiTietPhieuXuat;
            ChiTietPhieuXuat.DataSource = ctphieuxuatBLL.TimKiem_ChiTietPX(MaPX, TuKhoa);
        }
        //private void btnReport_Click(object sender, EventArgs e)
        //{
        //    lbMaPX.Text = MaPX;
        //    frmReport frm = new frmReport(lbMaPX.Text);
        //    frm.ShowDialog();
        //}
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        //private void getMaMH()
        //{
        //    AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
        //    string Makho = lbMaKho.Text;
        //    DataTable Mamh = PhieuXuatBLL.AutoComplace(Makho);
        //    for (int i = 0; i < Mamh.Rows.Count; i++)
        //    {
        //        auto.Add(Mamh.Rows[i]["MaMH"].ToString());
        //    }
        //    txtMaMH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtMaMH.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtMaMH.AutoCompleteCustomSource = auto;
        //}
        //private void getMaLo()
        //{
        //    AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
        //    string MaLo = txtMaMH.Text;
        //    DataTable Malo = PhieuXuatBLL.SelectMaLo(MaLo);
        //    for (int i = 0; i < Malo.Rows.Count; i++)
        //    {
        //        auto.Add(Malo.Rows[i]["MaLo"].ToString());
        //    }
        //    txtMaLo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtMaLo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtMaLo.AutoCompleteCustomSource = auto;
        //}
        //private void getMaKho()
        //{
        //    AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
        //    DataTable MaKho = PhieuXuatBLL.SelectMaKho();
        //    for (int i = 0; i < MaKho.Rows.Count; i++)
        //    {
        //        auto.Add(MaKho.Rows[i]["MaKho"].ToString());
        //    }
        //    txtMakho.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtMakho.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtMakho.AutoCompleteCustomSource = auto;
        //}
        //private void lbMaKho_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void txtMaMH_Click(object sender, EventArgs e)
        //{
        //    getMaMH();
        //}

        //private void txtMaLo_Click(object sender, EventArgs e)
        //{
        //    getMaLo();
        //}

        //private void txtSLXuat_TextChanged(object sender, EventArgs e)
        //{
        //    string MaMH = txtMaMH.Text;
        //    string MaLo = txtMaLo.Text;
        //    if(txtSLXuat.Text.Trim() != "")
        //    {
        //        if (Convert.ToInt32(txtSLXuat.Text) > PhieuXuatBLL.SelectSLXuat(MaLo, MaMH))
        //        {
        //            txtSLXuat.Text =Convert.ToString(PhieuXuatBLL.SelectSLXuat(MaLo, MaMH));
        //            MessageBox.Show("Làm gì còn hàng mà xuất nhiều thế :)", "Thông báo");
        //        }

        //    }

        //}

        //private void txtMakho_Click(object sender, EventArgs e)
        //{
        //    getMaKho();
        //}
    }
    
}

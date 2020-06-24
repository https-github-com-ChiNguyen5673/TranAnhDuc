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
    public partial class frmPhieunhap : Form
    {
        BindingSource PhieuNhap = new BindingSource();
        BindingSource ChiTietPhieuNhap = new BindingSource();
        PhieuNhapBLL PhieuNhapBLL = new PhieuNhapBLL();
        ChiTiet_PhieuNhapBLL ctphieunhapBLL = new ChiTiet_PhieuNhapBLL();
        NhanVienBLL nhanvien = new NhanVienBLL();
        private int MaPN;
        private int MaLo;
        public frmPhieunhap()
        {
            InitializeComponent();
            LoadPhieuNhap();
        }
        void LoadPhieuNhap()
        {
            Clear_Binding();
            dtgPhieuNhap.DataSource = PhieuNhap;
            PhieuNhap.DataSource = PhieuNhapBLL.PhieuNhap_Select();
            dtgPhieuNhap.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            Binding();
            dtgPhieuNhap.Refresh();
        }
        void Binding()
        {
            txtMaPN.DataBindings.Add(new Binding("Text", dtgPhieuNhap.DataSource, "Mã phiếu nhập", true, DataSourceUpdateMode.Never));
            dtpNgayNhap.DataBindings.Add(new Binding("Value", dtgPhieuNhap.DataSource, "Ngày nhập", true, DataSourceUpdateMode.Never));
            txtMaNV.DataBindings.Add(new Binding("Text", dtgPhieuNhap.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never));
            txtNCC.DataBindings.Add(new Binding("Text", dtgPhieuNhap.DataSource, "Mã nhà cung cấp", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding()
        {
            txtMaPN.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Clear();
            txtMaNV.DataBindings.Clear();
            txtNCC.DataBindings.Clear();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            int MaNV = Convert.ToInt32(txtMaNV.Text);
            int MaNCC = Convert.ToInt32(txtNCC.Text);
            string NgayNhap = dtpNgayNhap.Value.ToString("MM/dd/yyyy");
            PhieuNhap phieunhap = new PhieuNhap(-1, NgayNhap, MaNV, MaNCC);
            PhieuNhapBLL.PhieuNhap_Insert(phieunhap);
            LoadPhieuNhap();
          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int MaPN = Convert.ToInt32(txtMaPN.Text);
            int MaNV = Convert.ToInt32(txtMaNV.Text);
            int MaNCC = Convert.ToInt32(txtNCC.Text);
            string NgayNhap = dtpNgayNhap.Value.ToString("MM/dd/yyyy");
            NhanVien NV = new NhanVien(MaNV, "", "");
            PhieuNhap phieunhap = new PhieuNhap(MaPN, NgayNhap, MaNV, MaNCC);
            PhieuNhapBLL.PhieuNhap_Update(phieunhap);
            LoadPhieuNhap();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaPN = Convert.ToInt32(txtMaPN.Text);
            PhieuNhap phieunhap = new PhieuNhap(MaPN, "", -1,-1);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (PhieuNhapBLL.PhieuNhap_Delete(phieunhap))
                    LoadPhieuNhap();
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TuKhoa = txtTimKiem.Text;
            dtgPhieuNhap.DataSource = PhieuNhap;
            PhieuNhap.DataSource = PhieuNhapBLL.PhieuNhap_TimKiem(TuKhoa);
        }


        void LoadChiTietPhieuNhap()
        {
                        Clear_Binding_ChiTiet();            int MaPN = Convert.ToInt32 (txtMaPN.Text);;            lbMaPN.Text =Convert.ToString (MaPN);            PhieuNhap phieunhap = new PhieuNhap(MaPN, "", -1,-1);
            dtgChiTietPhieuNhap.DataSource = ChiTietPhieuNhap;
            ChiTietPhieuNhap.DataSource = PhieuNhapBLL.ChiTietPhieuNhap_Select(phieunhap);
            Binding_ChiTiet();
            dtgChiTietPhieuNhap.Refresh();


        }
        void Binding_ChiTiet()
        {
            txtMaLo.DataBindings.Add(new Binding("Text", dtgChiTietPhieuNhap.DataSource, "Mã lô", true, DataSourceUpdateMode.Never));
            txtSLNhap.DataBindings.Add(new Binding("Text", dtgChiTietPhieuNhap.DataSource, "Số lượng nhập", true, DataSourceUpdateMode.Never));
            txtSLGiao.DataBindings.Add(new Binding("Text", dtgChiTietPhieuNhap.DataSource, "Số lượng giao", true, DataSourceUpdateMode.Never));
            txtDVT.DataBindings.Add(new Binding("Text", dtgChiTietPhieuNhap.DataSource, "Đơn vị tính", true, DataSourceUpdateMode.Never));
            txtDonGiaNhap.DataBindings.Add(new Binding("Text", dtgChiTietPhieuNhap.DataSource, "Đơn giá nhập", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding_ChiTiet()
        {
            txtMaLo.DataBindings.Clear();
            txtSLNhap.DataBindings.Clear();
            txtSLGiao.DataBindings.Clear();
            txtDVT.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Clear();

        }

        private void txtSLXuat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnXemChiTietPN_Click(object sender, EventArgs e)
        {
            btnThemCTPN.Enabled = true;
            btnSuaCTPN.Enabled = true;
            btnXoaCTPN.Enabled = true;
            btnTimKiemChiTiet.Enabled = true;
            btnReport.Enabled = true;
            LoadChiTietPhieuNhap();
        }

        private void btnThemCTPN_Click(object sender, EventArgs e)
        {
            int MaPN = Convert.ToInt32(txtMaPN.Text);
            int MaLo = Convert.ToInt32(txtMaLo.Text);
            int SLNhap = Convert.ToInt32(txtSLNhap.Text);
            int SLGiao = Convert.ToInt32(txtSLGiao.Text);
            string DVT = txtDVT.Text;
            int DonGiaNhap = Convert.ToInt32(txtDonGiaNhap.Text);
            ChiTiet_PhieuNhap ctphieunhap = new ChiTiet_PhieuNhap(MaPN, MaLo, SLNhap,SLGiao,DVT, DonGiaNhap);
            if (ctphieunhapBLL.ChiTietPhieuNhap_Insert(ctphieunhap) == true)
                LoadChiTietPhieuNhap();
            else
                MessageBox.Show("Thêm thất bại");
        }
        private void btnSuaCTPN_Click(object sender, EventArgs e)
        {
            int MaPN = Convert.ToInt32(txtMaPN.Text);
            int MaLo = Convert.ToInt32(txtMaLo.Text);
            int SLNhap = Convert.ToInt32(txtSLNhap.Text);
            int SLGiao = Convert.ToInt32(txtSLGiao.Text);
            string DVT = txtDVT.Text; ;
            int DonGiaNhap = Convert.ToInt32(txtDonGiaNhap.Text);
            ChiTiet_PhieuNhap ctphieunhap = new ChiTiet_PhieuNhap(MaPN, MaLo, SLNhap, SLGiao, DVT, DonGiaNhap);
            if (ctphieunhapBLL.ChittietPhieuNhap_Update(ctphieunhap))
                LoadChiTietPhieuNhap();
            else
                MessageBox.Show("Chỉnh sửa thất bại");
        }

        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {

            int MaPN = Convert.ToInt32(txtMaPN.Text);
            int MaLo = Convert.ToInt32(txtMaLo.Text);
            ChiTiet_PhieuNhap ctphieunhap = new ChiTiet_PhieuNhap(MaPN, MaLo, -1, -1, "", -1);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (ctphieunhapBLL.ChittietPhieuNhap_Delete(ctphieunhap))
                    LoadChiTietPhieuNhap();
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

       

      

     
        


      
    

       

        
      
    }
}

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

namespace QLKho.GUI
{
    public partial class frmNhanVien : Form
    {
        BindingSource NhanVien = new BindingSource();
        NhanVienBLL NhanvienBLL = new NhanVienBLL();
        public frmNhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
        }
        void LoadNhanVien()
        {
            Clear_Binding();
            dtgNhanVien.DataSource = NhanVien;
            NhanVien.DataSource = NhanvienBLL.NhanVien_Select();
            Binding();
            dtgNhanVien.Refresh();
        }
        void Binding()
        {
            txtMaNV.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never));
            txtTenNV.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "Tên nhân viên", true, DataSourceUpdateMode.Never));
            txtBophan.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "Tên bộ phận", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding()
        {
            txtMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtBophan.DataBindings.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int MaNV =Convert.ToInt32 (txtMaNV.Text);
            string TenNV = txtTenNV.Text;
            string BoPhan = txtBophan.Text;
            NhanVien nhanvien = new NhanVien(MaNV, TenNV, BoPhan);
            NhanvienBLL.NhanVien_Insert(nhanvien);
            LoadNhanVien();
        }
       
        private void btnSua_Click(object sender, EventArgs e)
        {
            int MaNV = Convert.ToInt32(txtMaNV.Text);
            string TenNV = txtTenNV.Text;
            string BoPhan = txtBophan.Text;
            NhanVien nhanvien = new NhanVien(MaNV, TenNV, BoPhan);
            NhanvienBLL.NhanVien_Update(nhanvien);
            LoadNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaNV = Convert.ToInt32(txtMaNV.Text);
            string TenNV = txtTenNV.Text;
            NhanVien nhanvien = new NhanVien(MaNV,TenNV,"");
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (NhanvienBLL.NhanVien_Delete(nhanvien))
                {
                    LoadNhanVien();
               
          
                }
                    
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            int MaNV = Convert.ToInt32(txtMaNV.Text);
            NhanVien nhanvien = new NhanVien(MaNV, "", "");
            //if (NhanvienBLL.NhanVien_CheckMa(nhanvien))
            //{
            //    btnThem.Enabled = false;
            //    btnSua.Enabled = true;
            //    btnXoa.Enabled = true;
            //}
            //else
            //{
            //    btnThem.Enabled = true;
            //    btnSua.Enabled = false;
            //    btnXoa.Enabled = false;
            //}
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TuKhoa = txtTimKiem.Text;
            dtgNhanVien.DataSource = NhanVien;
            NhanVien.DataSource = NhanvienBLL.NhanVien_TimKiem(TuKhoa);
        }

        //private void txtBophan_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}

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
namespace QLKho
{
    public partial class frmNhaCC : Form
    {
        BindingSource NhaCC = new BindingSource();
        BindingSource NhaCCInsert = new BindingSource();
        BindingSource ChiTietNhaCC = new BindingSource();
        NhaCcBLL nhacc = new NhaCcBLL();
        public frmNhaCC()
        {
            InitializeComponent();
            LoadNhaCC();
        }
        void LoadNhaCC()
        {
            Clear_Binding();
            dtgNhaCC.DataSource = NhaCC;
            NhaCC.DataSource = nhacc.NhaCc_Select();
            Binding();
            dtgNhaCC.Refresh();
        }
        int MaNCC;
      

       
        void Binding()
        {
            txtMaNCC.DataBindings.Add(new Binding("Text", dtgNhaCC.DataSource, "Mã nhà cung cấp", true, DataSourceUpdateMode.Never));
            txtTenNCC.DataBindings.Add(new Binding("Text", dtgNhaCC.DataSource, "Tên nhà cung cấp", true, DataSourceUpdateMode.Never));
           
        }
        void Clear_Binding()
        {
            txtMaNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Clear();
           
        }

        //private void btnTimKiemChiTiet_Click(object sender, EventArgs e)
        //{
        //    MaNCC = txtMaNCC.Text;
        //    string TuKhoa = txtTimKiemChiTiet.Text;
        //    dtgChiTietKho.DataSource = ChiTietKho;
        //    ChiTietKho.DataSource = kho.TimKiemChiTietKho(MaKho, TuKhoa);
        //}

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TuKhoa = txtTimKiem.Text;
            dtgNhaCC.DataSource = NhaCC;
            NhaCC.DataSource = nhacc.Nhacc_TimKiem(TuKhoa);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MaNCC = Convert.ToInt32(txtMaNCC.Text);
            string TenNCC = txtTenNCC.Text;
            NhaCC NhaCC = new NhaCC(MaNCC,TenNCC);
            dtgNhaCC.DataSource = NhaCCInsert;
            NhaCCInsert.DataSource = nhacc.NhaCC_Insert(NhaCC);
            LoadNhaCC();
        }

     

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MaNCC = Convert.ToInt32(txtMaNCC.Text);
            NhaCC NhaCc = new NhaCC(MaNCC, "");
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (nhacc.Nhacc_Delete(NhaCc))
                    LoadNhaCC();
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MaNCC = Convert.ToInt32(txtMaNCC.Text);
            string TenNCC = txtTenNCC.Text;
          
            NhaCC Nhacc = new NhaCC(MaNCC, TenNCC);
            if (nhacc.Nhacc_Update(Nhacc))
                LoadNhaCC();
            else
                MessageBox.Show("Chỉnh sửa thất bại");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
       

        //private void label7_Click(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void txtMaNhaCC_TextChanged(object sender, EventArgs e)
        //{


        //}

        //private void groupBox3_Enter(object sender, EventArgs e)
        //{

        //}

        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}

        //private void txtTimKiem_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}

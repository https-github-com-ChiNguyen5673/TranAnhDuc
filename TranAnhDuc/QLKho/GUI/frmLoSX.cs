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
    public partial class frmLoSX : Form
    {
        BindingSource LoSX = new BindingSource();
        BindingSource ChiTietLoSx = new BindingSource();
        BindingSource Lo_Insert = new BindingSource();
        LoSxBLL LosxBill = new LoSxBLL();
        public frmLoSX()
        {
            InitializeComponent();
            LoadLoSx();
        }
        void LoadLoSx()
        {
            Clear_Binding();
            dtgLoSX.DataSource = LoSX;
            LoSX.DataSource = LosxBill.LoSx_Select();
            Binding();
            dtgLoSX.Refresh();
        }
        void Binding()
        {
            txtMaLo.DataBindings.Add(new Binding("Text", dtgLoSX.DataSource, "Mã Lô", true, DataSourceUpdateMode.Never));
            dtpNSX.DataBindings.Add(new Binding("Value", dtgLoSX.DataSource, "Ngày sản xuất", true, DataSourceUpdateMode.Never));
            dtpHSD.DataBindings.Add(new Binding("Value", dtgLoSX.DataSource, "Hạn sử dụng", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding()
        {
            txtMaLo.DataBindings.Clear();
            dtpNSX.DataBindings.Clear();
            dtpHSD.DataBindings.Clear();
        }
        void LoadChiTietLo()
        {
            string MaLo = txtMaLo.Text;
            lbMaLo.Text = MaLo;
            LoSX Losx = new LoSX(MaLo, "", "");
            dtgChiTietLoSX.DataSource = ChiTietLoSx;
            ChiTietLoSx.DataSource = LosxBill.ChiTietLoSX_Select(Losx);
        }
        private void btnXemKho_Click(object sender, EventArgs e)
        {
            LoadChiTietLo();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaLo = txtMaLo.Text;
            string NSX = dtpNSX.Value.ToString("MM/dd/yyyy");
            string HSD = dtpHSD.Value.ToString("MM/dd/yyyy");
            LoSX Losx = new LoSX(MaLo,NSX,HSD);
            dtgLoSX.DataSource = Lo_Insert;
            Lo_Insert.DataSource = LosxBill.LoSX_Insert(Losx);
            LoadLoSx();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaLo = txtMaLo.Text;
            LoSX Losx = new LoSX(MaLo, "", "");
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (LosxBill.LoSX_Delete(Losx))
                    LoadLoSx();
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void txtMaLo_TextChanged(object sender, EventArgs e)
        {
            string MaLo = txtMaLo.Text;
            LoSX Losx = new LoSX(MaLo, "", "");
            if (LosxBill.CheckMaLo(Losx))
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string MaLo = txtMaLo.Text;
            string NSX = dtpNSX.Value.ToString("MM/dd/yyyy");
            string HSD = dtpHSD.Value.ToString("MM/dd/yyyy");
            LoSX Losx = new LoSX(MaLo, NSX, HSD);
            if (LosxBill.LoSX_Update(Losx))
                LoadLoSx();
            else
                MessageBox.Show("Cập nhật thất bại");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TuKhoa = txtTimKiem.Text;
            dtgLoSX.DataSource = LoSX;
            LoSX.DataSource = LosxBill.LoSX_TimKiem(TuKhoa);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLKho.GUI;
namespace QLKho
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmKho kho = new frmKho();
        //    kho.ShowDialog();
        //}

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nhanvien = new frmNhanVien();
            nhanvien.ShowDialog();
        }

        private void phiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuXuat phieuxuat = new frmPhieuXuat();
            phieuxuat.ShowDialog();
        }

        private void lôSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoSX losx = new frmLoSX();
            losx.ShowDialog();
        }
        

        private void nhàCungCấpToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmNhaCC nhacc = new frmNhaCC();
            nhacc.ShowDialog();
        }

        private void phiếuNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPhieunhap phieunhap = new frmPhieunhap();
            phieunhap.ShowDialog();
        }
    }
}

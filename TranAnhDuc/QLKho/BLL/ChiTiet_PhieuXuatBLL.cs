using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKho.DAO;
using QLKho.Entity;

namespace QLKho.BLL
{
    public class ChiTiet_PhieuXuatBLL
    {
        private static ChiTiet_PhieuXuatBLL istance;

        public static ChiTiet_PhieuXuatBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new ChiTiet_PhieuXuatBLL();
                return istance;
            }
            private set { istance = value; }
        }
        public ChiTiet_PhieuXuatBLL() { }

        public ChiTiet_PhieuXuatDAO CT_PhieuXuat = new ChiTiet_PhieuXuatDAO();
        public bool ChiTietPhieuXuat_Insert(ChiTiet_PhieuXuat ctphieuxuat)
        {
            return CT_PhieuXuat.ChiTietPhieuXuat_Insert(ctphieuxuat);
        }
        public DataTable ChittietPhieuxuat_Load(ChiTiet_PhieuXuat ctphieuxuat)
        {
            return CT_PhieuXuat.ChiTietPhieuXuat_Load(ctphieuxuat);
        }
        public bool ChittietPhieuxuat_Update(ChiTiet_PhieuXuat ctphieuxuat)
        {
            return CT_PhieuXuat.ChiTietPhieuXuat_Update(ctphieuxuat);
        }
        public bool ChittietPhieuxuat_Delete(ChiTiet_PhieuXuat ctphieuxuat)
        {
            return CT_PhieuXuat.ChiTietPhieuXuat_Delete(ctphieuxuat);
        }
        //public bool CheckMaCTPhieuXuat(ChiTiet_PhieuXuat ctphieuxuat)
        //{
        //    return CT_PhieuXuat.CheckMaCTPhieuXuat(ctphieuxuat);
        //}
        public DataTable TimKiem_ChiTietPX(int MaPX,string TuKhoa)
        {
            return CT_PhieuXuat.TimKiem_CTPhieuXuat(MaPX, TuKhoa);
        }
    }
}

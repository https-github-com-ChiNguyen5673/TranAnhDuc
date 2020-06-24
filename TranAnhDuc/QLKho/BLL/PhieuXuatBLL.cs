using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLKho.DAO;
using QLKho.Entity;

namespace QLKho.BLL
{
    public class PhieuXuatBLL
    {
        private static PhieuXuatBLL istance;

        public static PhieuXuatBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new PhieuXuatBLL();
                return istance;
            }
            private set { istance = value; }
        }
        public PhieuXuatBLL() { }

        public PhieuXuatDAO Phieuxuat = new PhieuXuatDAO();
        public DataTable PhieuXuat_Select()
        {
            return Phieuxuat.PhieuXuat_Select();
        }
        public DataTable ChiTietPhieuXuat_Select(PhieuXuat phieuxuat)
        {
            return Phieuxuat.ChiTietPhieuXuat_Select(phieuxuat);
        }
        public int  PhieuXuat_Insert(PhieuXuat phieuxuat)
        {
            return Phieuxuat.PhieuXuat_Insert(phieuxuat);
        }
        public bool PhieuXuat_Update(PhieuXuat phieuxuat)
        {
            return Phieuxuat.PhieuXuat_Update(phieuxuat);
        }
        public bool PhieuXuat_Delete(PhieuXuat phieuxuat)
        {
            return Phieuxuat.PhieuXuat_Delete(phieuxuat);
        }
        public DataTable PhieuXuat_TimKiem(string TuKhoa)
        {
            return Phieuxuat.PhieuXuat_TimKiem(TuKhoa);
        }
        //public DataTable TenMH(MatHang mathang)
        //{
        //    return Phieuxuat.TenMH(mathang);
        //}
        //public bool CheckMaPhieuXuat(PhieuXuat phieuxuat)
        //{
        //    return Phieuxuat.CheckMaPhieuXuat(phieuxuat);
        //}
        //public DataTable TenKho(PhieuXuat phieuxuat)
        //{
        //    return Phieuxuat.TenKho(phieuxuat);
        //}
        //public DataTable AutoComplace(string MaKho)
        //{
        //    return Phieuxuat.AutoComplate(MaKho);
        //}
        //public DataTable SelectMaLo(string MaMH)
        //{
        //    return Phieuxuat.SelectMaLo(MaMH);
        //}
        //public int SelectSLXuat(string MaLo,string MaMH)
        //{
        //    return Phieuxuat.SelectSLXuat(MaLo, MaMH);
        //}
        //public DataTable SelectMaKho()
        //{
        //    return Phieuxuat.SelectMaKho();
        //}
    }
}

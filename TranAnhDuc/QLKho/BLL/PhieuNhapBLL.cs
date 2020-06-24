using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLKho.Entity;
using QLKho.DAO;


namespace QLKho.BLL
{
    public class PhieuNhapBLL
    {
        private static PhieuNhapBLL istance;

        public static PhieuNhapBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new PhieuNhapBLL();
                return istance;
            }
            private set { istance = value; }
        }
        public PhieuNhapBLL() { }

        public PhieuNhapDAO PhieuNhap = new PhieuNhapDAO();
        public DataTable PhieuNhap_Select()
        {
            return PhieuNhap.PhieuNhap_Select();
        }
        public DataTable ChiTietPhieuNhap_Select(PhieuNhap phieunhap)
        {
            return PhieuNhap.ChiTietPhieuNhap_Select(phieunhap);
        }
        public int PhieuNhap_Insert(PhieuNhap phieunhap)
        {
            return PhieuNhap.PhieuNhap_Insert(phieunhap);
        }
        public bool PhieuNhap_Update(PhieuNhap phieunhap)
        {
            return PhieuNhap.PhieuNhap_Update(phieunhap);
        }
        public bool PhieuNhap_Delete(PhieuNhap phieunhap)
        {
            return PhieuNhap.PhieuNhap_Delete(phieunhap);
        }
        public DataTable PhieuNhap_TimKiem(string TuKhoa)
        {
            return PhieuNhap.PhieuNhap_TimKiem(TuKhoa);
        }
        //public DataTable TenMH(MatHang mathang)
        //{
        //    return PhieuNhap.TenMH(mathang);
        //}
        //public bool CheckMaPhieuNhap(PhieuNhap PhieuNhap)
        //{
        //    return PhieuNhap.CheckMaPhieuNhap(PhieuNhap);
        //}
        //public DataTable TenKho(PhieuNhap PhieuNhap)
        //{
        //    return PhieuNhap.TenKho(PhieuNhap);
        //}
        //public DataTable AutoComplace(string MaKho)
        //{
        //    return PhieuNhap.AutoComplate(MaKho);
        //}
        //public DataTable SelectMaLo(string MaMH)
        //{
        //    return PhieuNhap.SelectMaLo(MaMH);
        //}
        //public int SelectSLXuat(string MaLo, string MaMH)
        //{
        //    return PhieuNhap.SelectSLXuat(MaLo, MaMH);
        //}
        //public DataTable SelectMaKho()
        //{
        //    return PhieuNhap.SelectMaKho();
        //}
    }
}

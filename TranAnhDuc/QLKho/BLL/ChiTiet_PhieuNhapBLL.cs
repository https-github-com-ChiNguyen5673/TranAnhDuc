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
    public class ChiTiet_PhieuNhapBLL
    {
        private static ChiTiet_PhieuNhapBLL istance;

        public static ChiTiet_PhieuNhapBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new ChiTiet_PhieuNhapBLL();
                return istance;
            }
            private set { istance = value; }
        }
        public ChiTiet_PhieuNhapBLL() { }

        public ChiTiet_PhieuNhapDAO CT_PhieuNhap = new ChiTiet_PhieuNhapDAO();
        public bool ChiTietPhieuNhap_Insert(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            return CT_PhieuNhap.ChiTietPhieuNhap_Insert(ctPhieuNhap);
        }
        public DataTable ChittietPhieuNhap_Load(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            return CT_PhieuNhap.ChiTietPhieuNhap_Load(ctPhieuNhap);
        }
        public bool ChittietPhieuNhap_Update(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            return CT_PhieuNhap.ChiTietPhieuNhap_Update(ctPhieuNhap);
        }
        public bool ChittietPhieuNhap_Delete(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            return CT_PhieuNhap.ChiTietPhieuNhap_Delete(ctPhieuNhap);
        }
        //public bool CheckMaCTPhieuNhap(ChiTiet_PhieuNhap ctPhieuNhap)
        //{
        //    return CT_PhieuNhap.CheckMaCTPhieuNhap(ctPhieuNhap);
        //}
        public DataTable TimKiem_ChiTietPX(string MaPX, string TuKhoa)
        {
            return CT_PhieuNhap.TimKiem_CTPhieuNhap(MaPX, TuKhoa);
        }
    }
}

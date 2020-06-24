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
    public class NhanVienBLL
    {
        private static NhanVienBLL istance;

        public static NhanVienBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new NhanVienBLL();
                return istance;
            }
            private set { istance = value; }
        }
        public NhanVienBLL() { }

        public NhanVienDAO Nhanvien = new NhanVienDAO();
        public DataTable NhanVien_Select()
        {
            return Nhanvien.Nhanvien_Select();
        }
        public bool NhanVien_Insert(NhanVien nhanvien)
        {
            return Nhanvien.NhanVien_Insert(nhanvien);
        }
        public bool NhanVien_Update(NhanVien nhanvien)
        {
            return Nhanvien.NhanVien_Update(nhanvien);
        }
        public bool NhanVien_Delete(NhanVien nhanvien)
        {
            return Nhanvien.NhanVien_Delete(nhanvien);
        }
        //public bool NhanVien_CheckMa(NhanVien nhanvien)
        //{
         //   return Nhanvien.Nhanvien_CheckMa(nhanvien);
        //}
        public DataTable NhanVien_TimKiem(string TuKhoa)
        {
            return Nhanvien.NhanVien_TimKiem(TuKhoa);
        }
    }
}

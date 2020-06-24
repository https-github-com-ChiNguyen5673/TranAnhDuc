using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKho.Entity;

namespace QLKho.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO istance;

        public static NhanVienDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new NhanVienDAO();
                return istance;
            }
            private set { istance = value; }
        }
        public NhanVienDAO() { }
        public DataTable Nhanvien_Select()
        {
            string query = "pro_NhanVien";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public bool NhanVien_Insert(NhanVien nhanvien)
        {
            try
            {
                string query = " pro_NhanVienInsert N'" + nhanvien.TenNV + "', N'" + nhanvien.BoPhan + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool NhanVien_Update(NhanVien nhanvien)
        {
            try
            {
                string query = " pro_NhanVienUpdate '" + nhanvien.MaNV + "',N'" + nhanvien.TenNV + "', N'" + nhanvien.BoPhan + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool NhanVien_Delete(NhanVien nhanvien)
        {
            try
            {
                string query = " pro_NhanVienDelete N'" + nhanvien.TenNV + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        //public bool Nhanvien_CheckMa(NhanVien nhanvien)
        //{
        //    string query = "sp_CheckMaNV '" + nhanvien.MaNV + "'";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        //   return result.Rows.Count > 0;
        //}
        public DataTable NhanVien_TimKiem(string TuKhoa)
        {
            string query = "pro_NhanVienTimKiem @TuKhoa";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { TuKhoa });
            return result;
        }
    }
}

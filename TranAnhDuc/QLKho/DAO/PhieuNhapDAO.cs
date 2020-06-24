using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLKho.Entity;

namespace QLKho.DAO
{
    public class PhieuNhapDAO
    {
        private static PhieuNhapDAO istance;

        public static PhieuNhapDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new PhieuNhapDAO();
                return istance;
            }
            private set { istance = value; }
        }
        public PhieuNhapDAO() { }
        public DataTable PhieuNhap_Select()
        {
            string query = "sp_PhieuNhap_Select";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable ChiTietPhieuNhap_Select(PhieuNhap PhieuNhap)
        {
            string query = "sp_CTPhieuNhap_Select '" + PhieuNhap.MaPN + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public int PhieuNhap_Insert(PhieuNhap PhieuNhap)
        {
            try
           {
                string query = "sp_PhieuNhap_Insert '" + PhieuNhap.NgayNhap + "', '" + PhieuNhap.MaNV + "', '" + PhieuNhap.MaNCC + "'";
               int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result;
            }
            catch (Exception e)
           { }
            return 0;
        }
        public bool PhieuNhap_Update(PhieuNhap PhieuNhap)
        {
            try
           {
               string query = "sp_PhieuNhap_Update '" + PhieuNhap.MaPN + "','" + PhieuNhap.NgayNhap + "', '" + PhieuNhap.MaNV + "', '" + PhieuNhap.MaNCC + "'";
               DataTable result = DataProvider.Instance.ExecuteQuery(query);
               return true;
           }
            catch (Exception e)
            { }
           return false;
        }
        public bool PhieuNhap_Delete(PhieuNhap PhieuNhap)
        {
            try
           {
                string query = " sp_PhieuNhap_Delete '" + PhieuNhap.MaPN + "'";
               int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
           { }
            return false;
        }
        public DataTable PhieuNhap_TimKiem(string TuKhoa)
        {
            string query = "sp_PhieuNhap_TimKiem @TuKhoa";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { TuKhoa });
            return result;
        }
        ////public DataTable TenMH(MatHang mathang)
        ////{
        ////    string query = "sp_TenMH_TheoMa '" + mathang.MaMH + "'";
        ////    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        ////    return result;
        ////}
        ////public bool CheckMaPhieuNhap(PhieuNhap PhieuNhap)
        ////{
        ////    string query = "sp_CheckMaPhieuNhap '" + PhieuNhap.MaPN + "'";
        ////    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        ////    return result.Rows.Count > 0;
        ////}
        ////public DataTable TenKho(PhieuNhap PhieuNhap)
        ////{
        ////    string query = "sp_SelectTenKho '" + PhieuNhap.MaPN + "'";
        ////    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        ////    return result;
        ////}
        ////public DataTable AutoComplate(string MaKho)
        ////{
        ////    string query = "sp_AutoComplate @MaKho";
        ////    DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaKho });
        ////    return result;
        ////}
        ////public DataTable SelectMaLo(string MaMH)
        ////{
        ////    string query = "sp_SelectMaLo @MaMH";
        ////    DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaMH });
        ////    return result;
        ////}
        ////public int SelectSLXuat(string MaLo, string MaMh)
        ////{
        ////    string query = "sp_SelectSLXuat @MaLo , @MaMH ";
        ////    int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { MaLo, MaMh }));
        ////    return result;
        ////}
        ////public DataTable SelectMaKho()
        ////{
        ////    string query = "sp_SelectMaKho ";
        ////    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        ////    return result;
        ////}
    }
}

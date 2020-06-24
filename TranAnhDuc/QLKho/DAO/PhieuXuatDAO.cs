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
    public class PhieuXuatDAO
    {
        private static PhieuXuatDAO istance;

        public static PhieuXuatDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new PhieuXuatDAO();
                return istance;
            }
            private set { istance = value; }
        }
        public PhieuXuatDAO() { }
        public DataTable PhieuXuat_Select()
        {
            string query = "pro_PhieuXuatSelect ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable ChiTietPhieuXuat_Select(PhieuXuat phieuxuat)
        {
            string query = "pro_ChiTietPhieuXuatSelect '" + phieuxuat.MaPX + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public int PhieuXuat_Insert(PhieuXuat phieuxuat)
        {
            try
            {
                string query = "pro_PhieuXuatInsert  '" + phieuxuat.MaNV + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result;
            }
            catch (Exception e)
            { }
            return 0;
        }
        public bool PhieuXuat_Update(PhieuXuat phieuxuat)
        {
            try
            {
                string query = "pro_PhieuXuatUpdate '" + phieuxuat.MaPX + "', '" + phieuxuat.NgayXuat + "',  '" + phieuxuat.MaNV + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool PhieuXuat_Delete(PhieuXuat phieuxuat)
        {
            try
            {
                string query = " pro_PhieuXuatDelete '" + phieuxuat.MaPX + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public DataTable PhieuXuat_TimKiem(string TuKhoa)
        {
            string query = "pro_PhieuXuatTimKiem @TuKhoa";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { TuKhoa });
            return result;
        }
        public DataTable TenMH (MatHang mathang)
        {
            string query = "sp_TenMH_TheoMa '" + mathang.MaMH + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        //public bool CheckMaPhieuXuat(PhieuXuat phieuxuat)
        //{
        //    string query = "sp_CheckMaPhieuXuat '" + phieuxuat.MaPX + "'";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        //   return result.Rows.Count > 0;
        //}
        //public DataTable TenKho(PhieuXuat phieuxuat)
        //{
        //    string query = "sp_SelectTenKho '" + phieuxuat.MaPX + "'";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        //    return result;
        //}
        //public DataTable AutoComplate(string MaKho)
        //{
        //    string query = "sp_AutoComplate @MaKho";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaKho });
        //    return result;
        //}
        //public DataTable SelectMaLo(string MaMH)
        //{
        //    string query = "sp_SelectMaLo @MaMH";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaMH });
        //    return result;
        //}
        //public int SelectSLXuat(string MaLo,string MaMh)
        //{
        //    string query = "sp_SelectSLXuat @MaLo , @MaMH ";
        //    int result =Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { MaLo , MaMh }));
        //    return result;
        //}
        //public DataTable SelectMaKho()
        //{
        //    string query = "sp_SelectMaKho ";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        //    return result;
        //}
    }
}

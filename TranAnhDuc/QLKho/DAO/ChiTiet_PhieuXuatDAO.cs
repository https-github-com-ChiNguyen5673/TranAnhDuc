using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKho.Entity;

namespace QLKho.DAO
{
    public class ChiTiet_PhieuXuatDAO
    {
        private static ChiTiet_PhieuXuatDAO istance;

        public static ChiTiet_PhieuXuatDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new ChiTiet_PhieuXuatDAO();
                return istance;
            }
            private set { istance = value; }
        }
        public ChiTiet_PhieuXuatDAO() { }
        public bool ChiTietPhieuXuat_Insert(ChiTiet_PhieuXuat ctphieuxuat)
        {
            try
            {
                string query = "pro_ChiTietPhieuXuatInsert '" + ctphieuxuat.MaPX + "','" + ctphieuxuat.MaLo + "','" + ctphieuxuat.SLXuat + "','" + ctphieuxuat.DVT + "','" + ctphieuxuat.DonGiaXuat + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public DataTable ChiTietPhieuXuat_Load(ChiTiet_PhieuXuat ctphieuxuat)
        {
            string query = "pro_ChiTietPhieuXuatSelect '" + ctphieuxuat.MaPX + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public bool ChiTietPhieuXuat_Update(ChiTiet_PhieuXuat ctphieuxuat)
        {
            try
            {
                string query = "pro_ChiTietPhieuXuatUpdate '" + ctphieuxuat.MaPX + "','" + ctphieuxuat.MaLo + "','" + ctphieuxuat.SLXuat + "','" + ctphieuxuat.DVT + "','" + ctphieuxuat.DonGiaXuat + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool ChiTietPhieuXuat_Delete(ChiTiet_PhieuXuat ctphieuxuat)
        {
            try
            {
                string query = "pro_ChiTietPhieuXuatDelete '" + ctphieuxuat.MaPX + "','" + ctphieuxuat.MaLo + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        //public bool CheckMaCTPhieuXuat(ChiTiet_PhieuXuat ctphieuxuat)
        //{
        //    string query = "sp_CheckMaCTPhieuXuat '"+ctphieuxuat.MaPX+"','"+ctphieuxuat.MaMH+"','"+ctphieuxuat.MaLo+"'";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        //    return result.Rows.Count > 0;
        //}
        public DataTable TimKiem_CTPhieuXuat(int MaPX,string TuKhoa)
        {
            
            string query = "pro_TimKiemCTPhieuXuat @MaPX , @TuKhoa ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaPX, TuKhoa });
            return result;
        }
    }
}

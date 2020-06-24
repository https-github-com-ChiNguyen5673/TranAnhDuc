using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKho.Entity;

namespace QLKho.DAO
{
    public class ChiTiet_PhieuNhapDAO
    {
        private static ChiTiet_PhieuNhapDAO istance;

        public static ChiTiet_PhieuNhapDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new ChiTiet_PhieuNhapDAO();
                return istance;
            }
            private set { istance = value; }
        }
        public ChiTiet_PhieuNhapDAO() { }
        public bool ChiTietPhieuNhap_Insert(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            try
            {
                string query = "sp_CTPhieuNhap_Insert '" + ctPhieuNhap.MaPN + "','" + ctPhieuNhap.MaLo + "','" + ctPhieuNhap.SLNhap + "','" + ctPhieuNhap.SLGiao + "','" + ctPhieuNhap.DVT + "','" + ctPhieuNhap.DonGiaNhap + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public DataTable ChiTietPhieuNhap_Load(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            string query = "sp_CTPhieuNhap_Select '" + ctPhieuNhap.MaPN + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public bool ChiTietPhieuNhap_Update(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            try
            {
                string query = "sp_CTPhieuNhap_Update '" + ctPhieuNhap.MaPN + "','" + ctPhieuNhap.MaLo + "','" + ctPhieuNhap.SLNhap + "','" + ctPhieuNhap.SLGiao + "','" + ctPhieuNhap.DVT + "','" + ctPhieuNhap.DonGiaNhap + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool ChiTietPhieuNhap_Delete(ChiTiet_PhieuNhap ctPhieuNhap)
        {
            try
            {
                string query = "sp_CTPhieuNhap_Delete '" + ctPhieuNhap.MaPN + "','" + ctPhieuNhap.MaLo + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        //public bool CheckMaCTPhieuNhap(ChiTiet_PhieuNhap ctPhieuNhap)
        //{
        //    string query = "sp_CheckMaCTPhieuNhap '" + ctPhieuNhap.MaPN + "','" + ctPhieuNhap.MaMH + "','" + ctPhieuNhap.MaLo + "'";
        //    DataTable result = DataProvider.Instance.ExecuteQuery(query);
        //    return result.Rows.Count > 0;
        //}
        public DataTable TimKiem_CTPhieuNhap(string MaPN, string TuKhoa)
        {
            string query = "sp_TimKiemCTPhieuNhap @MaPN , @TuKhoa ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaPN, TuKhoa });
            return result;
        }
    }
}

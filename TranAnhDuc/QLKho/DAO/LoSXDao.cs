using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKho.Entity;
namespace QLKho.DAO
{
    public class LoSxDAO
    {
        private static LoSxDAO istance;

        public static LoSxDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new LoSxDAO();
                return istance;
            }
            private set { istance = value; }
        }
        public LoSxDAO() { }
        public DataTable LoSx_Select()
        {
            string query = "sp_LSX_Select";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable ChiTietLoSx_Select(LoSX Losx)
        {
            string query = "sp_XemChiTietLoSx '" + Losx.MaLo + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public bool LoSX_Insert(LoSX Losx)
        {
            try
            {
                string query = " sp_LoSX_Insert '" + Losx.MaLo + "', '" + Losx.NSX + "', '" + Losx.HSD + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool LoSX_Delete(LoSX Losx)
        {
            try
            {
                string query = " sp_LoSX_Delete '" + Losx.MaLo + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool CheckMaLo (LoSX Losx)
        {
            string query = "sp_CheckMaLo '" + Losx.MaLo + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public bool LoSX_Update(LoSX Losx)
        {
            try
            {
                string query = " sp_LoSX_Update '" + Losx.MaLo + "', '" + Losx.NSX + "', '" + Losx.HSD + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public DataTable LoSX_TimKiem(string TuKhoa)
        {
            string query = "sp_TimKiemLoSX @TuKhoa";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { TuKhoa });
            return result;
        }
    }
}

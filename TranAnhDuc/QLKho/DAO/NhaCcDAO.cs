using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKho.Entity;
namespace QLKho.DAO
{
    public class NhaCcDAO
    {
        private static NhaCcDAO istance;

        public static NhaCcDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new NhaCcDAO();
                return istance;
            }
            private set { istance = value; }
        }
        public NhaCcDAO() { }
        public DataTable NhaCc_Select()
        {
            string query = "sp_NhaCC_Select";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
       
        public bool NhaCc_Insert(NhaCC NhaCc)
        {
            try
            {
                string query = " sp_NhaCC_Insert '" + NhaCc.TenNCC  + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool NhaCc_Delete(NhaCC NhaCc)
        {
            try
            {
                string query = " sp_NhaCC_Delete '" + NhaCc.MaNCC + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
       
        public bool NhaCc_Update(NhaCC NhaCc)
        {
            try
            {
                string query = " sp_NhaCc_Update '" + NhaCc.MaNCC + "', '" + NhaCc.TenNCC  + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public DataTable NhaCc_TimKiem(string TuKhoa)
        {
            string query = "[sp_NhaCC_TimKiem] @TuKhoa";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { TuKhoa });
            return result;
        }
    }
}

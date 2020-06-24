using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKho.DAO;
using QLKho.BLL;
using QLKho.Entity;

namespace QLKho.BLL
{
    public class NhaCcBLL
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
        public NhaCcBLL() { }
        public NhaCcDAO Nhacc = new NhaCcDAO();
        public DataTable NhaCc_Select()
        {
            return Nhacc.NhaCc_Select();
        }
       
        public bool NhaCC_Insert(NhaCC NhaCC)
        {
            return Nhacc.NhaCc_Insert(NhaCC);
        }
        public bool Nhacc_Delete(NhaCC NhaCC)
        {
            return Nhacc.NhaCc_Delete(NhaCC);
        }

        public bool Nhacc_Update(NhaCC NhaCC)
        {
            return Nhacc.NhaCc_Update(NhaCC);
        }
        public DataTable Nhacc_TimKiem(string TuKhoa)
        {
            return Nhacc.NhaCc_TimKiem(TuKhoa);
        }
    }
}

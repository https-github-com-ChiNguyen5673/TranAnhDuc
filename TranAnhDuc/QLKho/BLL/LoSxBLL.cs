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
    public class LoSxBLL
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
        public LoSxBLL() { }
        public LoSxDAO Losx = new LoSxDAO();
        public DataTable LoSx_Select()
        {
            return Losx.LoSx_Select();
        }
        public DataTable ChiTietLoSX_Select(LoSX LoSX)
        {
            return Losx.ChiTietLoSx_Select(LoSX);
        }
        public bool LoSX_Insert(LoSX LoSX)
        {
            return Losx.LoSX_Insert(LoSX);
        }
        public bool LoSX_Delete(LoSX LoSX)
        {
            return Losx.LoSX_Delete(LoSX);
        }
        public bool CheckMaLo(LoSX LoSX)
        {
            return Losx.CheckMaLo(LoSX);
        }
        public bool LoSX_Update(LoSX LoSX)
        {
            return Losx.LoSX_Update(LoSX);
        }
        public DataTable LoSX_TimKiem(string TuKhoa)
        {
            return Losx.LoSX_TimKiem(TuKhoa);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class NhaCC
    {
        private int _MaNCC;
        private string _TenNCC;
       
        public NhaCC()
        {
            _MaNCC = -1;
            _TenNCC = "";
            
        }
        public NhaCC(int MaNCC, string TenNCC)
        {
            this._MaNCC = MaNCC;
            this._TenNCC = TenNCC;
            
        }
        public int MaNCC
        {
            set
            {
                this._MaNCC = value;
            }
            get
            {
                return this._MaNCC;
            }
        }
        public string TenNCC
        {
            set
            {
                this._TenNCC = value;
            }
            get
            {
                return this._TenNCC;
            }
        }
       
    }
}
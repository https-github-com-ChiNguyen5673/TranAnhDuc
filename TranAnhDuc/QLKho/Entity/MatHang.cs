using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class MatHang
    {
        private string _MaMH;
        private string _TenMH;
        public MatHang()
        {
            _MaMH = "";
            _TenMH = "";
        }
        public MatHang(string MaMH, string TenMH)
        {
            this._MaMH = MaMH;
            this._TenMH = TenMH;
        }
        public string MaMH
        {
            set
            {
                this._MaMH = value;
            }
            get
            {
                return this._MaMH;
            }
        }
        public string TenMH
        {
            set
            {
                this._TenMH = value;
            }
            get
            {
                return this._TenMH;
            }
        }
    }
}

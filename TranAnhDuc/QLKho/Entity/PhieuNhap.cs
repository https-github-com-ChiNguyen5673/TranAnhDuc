using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class PhieuNhap
    {
        private int _MaPN;
        private string _NgayNhap;
        private int _MaNCC;
        private int _MaNV;
        public PhieuNhap()
        {
            _MaPN = -1;
            _NgayNhap = "";
            _MaNCC = -1;
            _MaNV = -1;
        }
        public PhieuNhap(int MaPN, string NgayNhap, int MaNCC, int MaNV)
        {
            this._MaPN = MaPN;
            this._NgayNhap = NgayNhap;
            this._MaNCC = MaNCC;
            this._MaNV = MaNV;
        }
        public int MaPN
        {
            set
            {
                this._MaPN = value;
            }
            get
            {
                return this._MaPN;
            }
        }
        public string NgayNhap
        {
            set
            {
                this._NgayNhap = value;
            }
            get
            {
                return this._NgayNhap;
            }
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
        public int MaNV
        {
            set
            {
                this._MaNV = value;
            }
            get
            {
                return this._MaNV;
            }
        }
    }
}

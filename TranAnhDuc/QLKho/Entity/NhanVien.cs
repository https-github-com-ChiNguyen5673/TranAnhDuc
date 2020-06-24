using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class NhanVien
    {
        private int _MaNV;
        private string _TenNV;
        private string _BoPhan;
        public NhanVien()
        {
            _MaNV = -1;
            _TenNV = "";
            _BoPhan = "";
        }
        public NhanVien(int MaNV, string TenNV, string BoPhan)
        {
            this._MaNV = MaNV;
            this._TenNV = TenNV;
            this._BoPhan = BoPhan;
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
        public string TenNV
        {
            set
            {
                this._TenNV = value;
            }
            get
            {
                return this._TenNV;
            }
        }
        public string BoPhan
        {
            set
            {
                this._BoPhan = value;
            }
            get
            {
                return this._BoPhan;
            }
        }
    }
}

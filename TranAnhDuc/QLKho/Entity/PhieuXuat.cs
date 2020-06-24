using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class PhieuXuat
    {
        private int _MaPX;
        private string _NgayXuat;
        private int _MaNV;
        public PhieuXuat()
        {
            _MaPX = -1;
            _NgayXuat = "";
            _MaNV = -1;
        }
        public PhieuXuat(int MaPX, string NgayXuat, int MaNV)
        {
            this._MaPX = MaPX;
            this._NgayXuat = NgayXuat;
            this._MaNV = MaNV;
        }
        public int MaPX
        {
            set
            {
                this._MaPX = value;
            }
            get
            {
                return this._MaPX;
            }
        }
        public string NgayXuat
        {
            set
            {
                this._NgayXuat = value;
            }
            get
            {
                return this._NgayXuat;
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

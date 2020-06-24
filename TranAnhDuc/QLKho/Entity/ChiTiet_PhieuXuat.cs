using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class ChiTiet_PhieuXuat
    {
        private int _MaPX;
        private string _DVT;
        private int _MaLo;
        private int _SLXuat;
        private int _DonGiaXuat;
        public ChiTiet_PhieuXuat()
        {
            _MaPX = -1;
            _DVT = "";
            _MaLo = -1;
            _SLXuat = -1;
            _DonGiaXuat = -1;
        }
        public ChiTiet_PhieuXuat(int MaPX, string DVT, int MaLo,int SLXuat, int DonGiaXuat)
        {
            this._MaPX = MaPX;
            this._DVT = DVT;
            this._MaLo = MaLo;
            this._SLXuat = SLXuat;
            this._DonGiaXuat = DonGiaXuat;
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
        public string DVT
        {
            set
            {
                this._DVT = value;
            }
            get
            {
                return this._DVT;
            }
        }
        public int MaLo
        {
            set
            {
                this._MaLo = value;
            }
            get
            {
                return this._MaLo;
            }
        }
        public int SLXuat
        {
            set
            {
                this._SLXuat = value;
            }
            get
            {
                return this._SLXuat;
            }
        }
        public int DonGiaXuat
        {
            set
            {
                this._DonGiaXuat = value;
            }
            get
            {
                return this._DonGiaXuat;
            }
        }
    }
}

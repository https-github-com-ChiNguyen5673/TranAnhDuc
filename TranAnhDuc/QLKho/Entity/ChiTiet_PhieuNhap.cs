using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class ChiTiet_PhieuNhap
    {
        private int _MaPN;
        private int _MaLo;
        private int _SLNhap;
        private int _SLGiao;
        private string _DVT;
        private int _DonGiaNhap;
        public ChiTiet_PhieuNhap()
        {
            _MaPN = -1;
            _MaLo = -1;
            _SLNhap = -1;
            _SLGiao = -1;
            _DVT="";
            _DonGiaNhap=-1;
        }
        public ChiTiet_PhieuNhap(int MaPN,  int MaLo, int SLNhap,int SLGiao,string DVT,int DonGiaNhap)
        {
            this._MaPN = MaPN;
            this._MaLo = MaLo;
            this._SLNhap = SLNhap;
            this._SLGiao = SLGiao;
            this._DVT = DVT;
            this._DonGiaNhap = DonGiaNhap;

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
        public int SLNhap
        {
            set
            {
                this._SLNhap = value;
            }
            get
            {
                return this._SLNhap;
            }
        }
        public int SLGiao
        {
            set
            {
                this._SLGiao = value;
            }
            get
            {
                return this._SLGiao;
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
         public int DonGiaNhap
        {
            set
            {
                this._DonGiaNhap = value;
            }
            get
            {
                return this._DonGiaNhap;
            }
        }
    }
}

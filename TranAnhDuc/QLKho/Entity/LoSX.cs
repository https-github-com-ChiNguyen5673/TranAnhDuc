using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKho.Entity
{
    public class LoSX
    {
        private string _MaLo;
        private string _NSX;
        private string _HSD;
        public LoSX()
        {
            _MaLo = "";
            _NSX = "";
            _HSD = "";
        }
        public LoSX(string MaLo, string NSX, string HSD)
        {
            this._MaLo = MaLo;
            this._NSX = NSX;
            this._HSD = HSD;
        }
        public string MaLo
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
        public string NSX
        {
            set
            {
                this._NSX = value;
            }
            get
            {
                return this._NSX;
            }
        }
        public string HSD
        {
            set
            {
                this._HSD = value;
            }
            get
            {
                return this._HSD;
            }
        }
    }
}

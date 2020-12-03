using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class SanBay
    {
        private string maSanBay;
        private string tenSanBay;
        private string tinh;
        private string quocGia;

        public SanBay() { }

        public SanBay(string maSanBay, string tenSanBay, string tinh, string quocGia)
        {
            this.MaSanBay = maSanBay;
            this.TenSanBay = tenSanBay;
            this.Tinh = tinh;
            this.QuocGia = quocGia;
        }

        public string MaSanBay { get => maSanBay; set => maSanBay = value; }
        public string TenSanBay { get => tenSanBay; set => tenSanBay = value; }
        public string Tinh { get => tinh; set => tinh = value; }
        public string QuocGia { get => quocGia; set => quocGia = value; }
    }
}

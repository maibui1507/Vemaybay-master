using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class SanBayTrungGian
    {
        private string maSanBay;
        private string maChuyenBay;
        private int thoiGianDung;

        public SanBayTrungGian() { }

        public SanBayTrungGian(string maSanBay, string maChuyenBay, int thoiGianDung)
        {
            this.MaSanBay = maSanBay;
            this.MaChuyenBay = maChuyenBay;
            this.ThoiGianDung = thoiGianDung;
        }

        public string MaSanBay { get => maSanBay; set => maSanBay = value; }
        public string MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public int ThoiGianDung { get => thoiGianDung; set => thoiGianDung = value; }
    }
}

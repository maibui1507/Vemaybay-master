using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class ChuyenBay
    {
        private string maChuyenBay;
        private string giaVeHang1;
        private string giaVeHang2;
        private string sanBayDi;
        private string sanBayDen;
        private string ngay;
        private string gio;
        private string thoiGianBay;
        private int hang1;
        private int hang2;
        private int hang1ConLai;
        private int hang2ConLai;

        public ChuyenBay() { }

        public ChuyenBay(string maChuyenBay, string giaVeHang1, string giaVeHang2, string sanBayDi, string sanBayDen,
            string ngay, string giaVeHangiog1, string thoiGianBay, int hang1, int hang2, int hang1ConLai, int hang2ConLai)
        {
            this.MaChuyenBay = maChuyenBay;
            this.GiaVeHang1 = giaVeHang1;
            this.GiaVeHang2 = giaVeHang2;
            this.SanBayDi = sanBayDi;
            this.SanBayDen = sanBayDen;
            this.Ngay = ngay;
            this.GiaVeHang1 = giaVeHang1;
            this.GiaVeHang2 = giaVeHang2;
            this.ThoiGianBay = thoiGianBay;
            this.Hang1 = hang1;
            this.Hang2 = hang2;
            this.Hang1ConLai = hang1ConLai;
            this.Hang2ConLai = hang2ConLai;
        }

        public string MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string GiaVeHang1 { get => giaVeHang1; set => giaVeHang1 = value; }
        public string GiaVeHang2 { get => giaVeHang2; set => giaVeHang2 = value; }
        public string SanBayDi { get => sanBayDi; set => sanBayDi = value; }
        public string SanBayDen { get => sanBayDen; set => sanBayDen = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string Gio { get => gio; set => gio = value; }
        public string ThoiGianBay { get => thoiGianBay; set => thoiGianBay = value; }
        public int Hang1 { get => hang1; set => hang1 = value; }
        public int Hang2 { get => hang2; set => hang2 = value; }
        public int Hang1ConLai { get => hang1ConLai; set => hang1ConLai = value; }
        public int Hang2ConLai { get => hang2ConLai; set => hang2ConLai = value; }
    }
}

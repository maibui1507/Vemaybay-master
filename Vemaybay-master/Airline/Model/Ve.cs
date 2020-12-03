using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class Ve
    {
        private string maVe;
        private string maChuyenBay;
        private string maKhachHang;
        private string hangVe;
        private float giaVe;
        private string ngayDatVe;

        public Ve() { }

        public Ve(string maVe, string maChuyenBay, string maKhachHang, string hangVe, float giaVe, string ngayDatVe)
        {
            this.MaVe = maVe;
            this.MaChuyenBay = maChuyenBay;
            this.MaKhachHang = maKhachHang;
            this.HangVe = hangVe;
            this.GiaVe = giaVe;
            this.NgayDatVe = ngayDatVe;
        }

        public string MaVe { get => maVe; set => maVe = value; }
        public string MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HangVe { get => hangVe; set => hangVe = value; }
        public float GiaVe { get => giaVe; set => giaVe = value; }
        public string NgayDatVe { get => ngayDatVe; set => ngayDatVe = value; }
    }
}

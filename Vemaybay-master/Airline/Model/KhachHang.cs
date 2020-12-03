using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class KhachHang
    {
        private string maKhachHang;
        private string hoTen;
        private int gioiTinh;
        private string soDienThoai;
        private string diaChi;
        private string cmnd;
        private string email;
        public KhachHang() { }

        public KhachHang(string maKhachHang, string hoTen, int gioiTinh, string soDienThoai, string diaChi, string cmnd, string email)
        {
            this.MaKhachHang = maKhachHang;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.Cmnd = cmnd;
            this.Email = email;
        }

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Email { get => email; set => email = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class NguoiDung
    {
        private string maNguoiDung;
        private string tenNguoiDung;
        private string matKhau;
        private string loaiNguoiDung;
        private string hoTen;
        
        public NguoiDung() { }

        public NguoiDung(string maNguoiDung, string tenNguoiDung, string matKhau, string loaiNguoiDung, string hoTen)
        {
            this.MaNguoiDung = maNguoiDung;
            this.TenNguoiDung = tenNguoiDung;
            this.MatKhau = matKhau;
            this.LoaiNguoiDung = loaiNguoiDung;
            this.HoTen = hoTen;
        }

        public string MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string TenNguoiDung { get => tenNguoiDung; set => tenNguoiDung = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string LoaiNguoiDung { get => loaiNguoiDung; set => loaiNguoiDung = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
    }
}

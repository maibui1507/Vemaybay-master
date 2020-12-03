using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class QuyDinh6
    {
        private int soLuongSanBay;
        private int thoiGianBayToiThieu;
        private int soSanBayTrungGianToiDa;
        private int thoiGianDungToiDa;
        private int thoiGianDungToiThieu;
        private int soLuongVeHang1;
        private int soLuongVeHang2;
        private int thoiGianDatVeChamNhat;
        private int thoiGianHuyDatVe;

        public QuyDinh6() { }

        public QuyDinh6(int soLuongSanBay, int thoiGianBayToiThieu, int soSanBayTrungGianToiDa, int thoiGianDungToiDa, int thoiGianDungToiThieu, int soLuongVeHang1, int soLuongVeHang2, int thoiGianDatVeChamNhat, int thoiGianHuyDatVe)
        {
            this.SoLuongSanBay = soLuongSanBay;
            this.ThoiGianBayToiThieu = thoiGianBayToiThieu;
            this.SoSanBayTrungGianToiDa = soSanBayTrungGianToiDa;
            this.ThoiGianDungToiDa = thoiGianDungToiDa;
            this.ThoiGianDungToiThieu = thoiGianDungToiThieu;
            this.SoLuongVeHang1 = soLuongVeHang1;
            this.SoLuongVeHang2 = soLuongVeHang2;
            this.ThoiGianDatVeChamNhat = thoiGianDatVeChamNhat;
            this.ThoiGianHuyDatVe = thoiGianHuyDatVe;
        }

        public int SoLuongSanBay { get => soLuongSanBay; set => soLuongSanBay = value; }
        public int ThoiGianBayToiThieu { get => thoiGianBayToiThieu; set => thoiGianBayToiThieu = value; }
        public int SoSanBayTrungGianToiDa { get => soSanBayTrungGianToiDa; set => soSanBayTrungGianToiDa = value; }
        public int ThoiGianDungToiDa { get => thoiGianDungToiDa; set => thoiGianDungToiDa = value; }
        public int ThoiGianDungToiThieu { get => thoiGianDungToiThieu; set => thoiGianDungToiThieu = value; }
        public int SoLuongVeHang1 { get => soLuongVeHang1; set => soLuongVeHang1 = value; }
        public int SoLuongVeHang2 { get => soLuongVeHang2; set => soLuongVeHang2 = value; }
        public int ThoiGianDatVeChamNhat { get => thoiGianDatVeChamNhat; set => thoiGianDatVeChamNhat = value; }
        public int ThoiGianHuyDatVe { get => thoiGianHuyDatVe; set => thoiGianHuyDatVe = value; }
    }
}

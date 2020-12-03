using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DAO;
namespace Airline.Model
{
    class Form1DAO
    {
        public string command = "";
        public Form1DAO()
        {
            ConnectEntity.Connection.OpenConn();
        }
        public void ExcuteCommand(string command)
        {
            SqlCommand cmd = new SqlCommand(command, ConnectEntity.Connection.Connection);
            cmd.ExecuteNonQuery();
        }
        public string Update_Sanbay(string maSanBay,string tenSanBay,string tinh,string quocGia)
        {
            command = "INSERT INTO SANBAY VALUES("
                                             + "'" + maSanBay + "'" + ", "
                                             + "N'" + tenSanBay + "'" + ", "
                                             + "N'" + tinh + "'" + ", " + "N'" + quocGia + "'" + ")";
            return command;
        }
        public string Update_ChuyenBay(string maChuyenBay, long giaVeHang1,long giaVeHang2,string sanBayDi,string sanBayDen,
            string ngayBay,string gioBay,int thoiGianBay,int hang1,int hang2,int hang1conlai,int hang2conlai)
        {
            command = "insert into chuyenbay values("
                                             + "'" + maChuyenBay + "'" + ", "
                                             + giaVeHang2 + ", " + giaVeHang1 + ", " + "'" + sanBayDi + "'" + ", "
                                             + "'" + sanBayDen + "'" + ", " + "'" + ngayBay + "'" + ", "
                                             + "'" + gioBay + "'" + ", " + thoiGianBay + ", " + hang1 + ", "
                                             + hang2 + ", " + hang1conlai + ", " + hang2conlai + ")";
            return command;
        }
        public string Update_SanBayTrungGian(string chuyenBay,string sanbay,int thoiGianDung)
        {
            command = "INSERT INTO SANBAYTRUNGGIAN VALUES("
                                             + "'" + chuyenBay + "'" + ", "
                                             + "'" + sanbay + "'" + ", "
                                             + thoiGianDung + ")";
            return command;
        }
        
    }
}

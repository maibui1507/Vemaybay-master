using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
     public class LoginModel
    {
        private static ConnectToSQL connection = new ConnectToSQL();
        internal static ConnectToSQL Connection { get => connection; set => connection = value; }
        public LoginModel(){
            Connection.OpenConn();
        }
        public DataTable Check_account(string username, string password)
        {
            string sql = "SELECT TENNGUOIDUNG, MATKHAU, LOAINGUOIDUNG FROM NGUOIDUNG WHERE TENNGUOIDUNG = '"
                + username + "' AND MATKHAU = '" + password + "'";
            DataTable dataTable = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter(sql, Connection.Connection);

            data.Fill(dataTable);
            data.Dispose();
            Connection.CloseConn();
            return dataTable;
        }
         ~LoginModel()
        {
            Connection.CloseConn();
        }

    }
}

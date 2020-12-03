using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DAO;

namespace Airline.DAO
{
    class LoginDAO
    {
        public static ConnectEntity connectEntity = new ConnectEntity();
        public LoginDAO()
        {

        }
        public DataTable Check_account(string username, string password)
        {
            string sql = "SELECT TENNGUOIDUNG, MATKHAU, LOAINGUOIDUNG FROM NGUOIDUNG WHERE TENNGUOIDUNG = '"
                + username + "' AND MATKHAU = '" + password + "'";
            DataTable dataTable = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter(sql, ConnectEntity.Connection.Connection);


            data.Fill(dataTable);
            data.Dispose();
            ConnectEntity.Connection.CloseConn();
            return dataTable;
        }
        ~LoginDAO()
        {
            ConnectEntity.Connection.CloseConn();
        }
    }
}

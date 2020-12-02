using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airline.Model;
namespace Airline.Controller
{
    class LoginController
    {
        private static LoginModel loginModel = new LoginModel();
       
        public static string loaiNguoiDung;
       
        public LoginController() {
            
        }
        public bool Check_Login(string username, string password)
        {
            bool check = false;
            DataTable dataTable = loginModel.Check_account(username, password);
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Incorrect username or password !", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                check = true;
                DataRow row = dataTable.Select()[0];
                loaiNguoiDung = row[2].ToString();
                //Console.WriteLine("login COntroller" + loaiNguoiDung);
                
            }
            return check;
        }
    }
}

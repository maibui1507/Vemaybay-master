using Airline.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airline.Controller;
namespace Airline
{
    public partial class LoginForm : Form
    {
        #region INIT
        
        public static string accountName;
        public static string loaiNguoiDung;
        private static ConnectToSQL connection =new ConnectToSQL();
        private static LoginController loginController = new LoginController();

        internal static ConnectToSQL Connection { get => connection; set => connection = value; }

        public string AccountName { get => accountName; set => accountName = value; }

        public LoginForm()
        {
            Connection.OpenConn();
            InitializeComponent();
            tbPassword.isPassword = true;
        }

        #endregion



        #region Main Event      

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbUser.Text;
            string password = tbPassword.Text;
            accountName = tbUser.Text;


            
            bool check = loginController.Check_Login(username, password);
            if (check == true) {
                loaiNguoiDung = LoginController.loaiNguoiDung;
                Console.WriteLine(loaiNguoiDung);
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "@@@@@@@@";
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "@@@@@@@@")
                tbPassword.Text = "";
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = tbUser.Text;
                string password = tbPassword.Text;
                accountName = username;

                bool check = loginController.Check_Login(username, password);
                if (check == true)
                {
                    loaiNguoiDung = LoginController.loaiNguoiDung;
                    
                    this.Hide();
                    Form1 form = new Form1();
                    form.Show();
                }
            }

        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = tbUser.Text;
                string password = tbPassword.Text;
                accountName = username;

                bool check = loginController.Check_Login(username, password);
                if (check == true)
                {
                    loaiNguoiDung = LoginController.loaiNguoiDung;
                    this.Hide();
                    Form1 form = new Form1();
                    form.Show();
                }
            }
        }

        #endregion

        #region ON - OFF

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\login_background1.jpg"));
                var bm = new Bitmap(this.BackgroundImage, new Size(this.Width, this.Height));
            this.BackgroundImage = bm;
        }
    }
}

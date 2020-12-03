using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using Airline.Model;
using Airline.DAO;
using Airline.Controller;

namespace Airline
{
    public partial class Form1 : Form
    {
        #region INIT

        SearchControl searchControl1;
        ReportControl reportControl1=new ReportControl();
        RuleChangeControl ruleChangeControl1;
        static public SaleControl saleControl1;
        private Form1Controller form1Controller = new Form1Controller();
        

        public Form1()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            label1.Text = "Hello " + LoginForm.accountName.ToUpper();

        }

        #endregion

        #region Main button

        private void saleBt_Click(object sender, EventArgs e)
        {
            HidePicture();
            searchControl1.Visible = true;
            searchControl1.BringToFront();
        }
        //private bool CheckUser(string s)
        //{ 
        //    if (s == "True")
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private void dataBt_Click(object sender, EventArgs e)
        {
            form1Controller.Update_DB(openFileDialog1);

        }

        private void reportBt_Click(object sender, EventArgs e)
        {
            if (form1Controller.CheckUser(LoginForm.loaiNguoiDung))
            {

                HidePicture();
                reportControl1.Visible = true;
                reportControl1.BringToFront();
            }
            else
            {
                MessageBox.Show("You don't have permission !");
            }

            }

        private void changeBt_Click(object sender, EventArgs e)
        {
            if (form1Controller.CheckUser(LoginForm.loaiNguoiDung))
            {
                HidePicture();
            ruleChangeControl1.Visible = true;
            ruleChangeControl1.BringToFront();
            }
            else
            {
                MessageBox.Show("You don't have permission !");
            }

        }

        #endregion

        #region Phím chức năng

        private void closeBt_Click(object sender, EventArgs e)
        {
            ConnectEntity.Connection.CloseConn();
            this.Close();
        }

        private void minimizeBt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Form moving

        Boolean flag;
        int x;
        int y;
        private void TaskBar_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            x = e.X;
            y = e.Y;
        }

        private void TaskBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
            }
        }

        private void TaskBar_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        #endregion

        #region Support Methods

        public static string ChuanHoaMa(int Code)
        {
            if (Code < 10)
            {
                return "00" + Code.ToString();
            }
            else
                if (Code < 100)
            {
                return "0" + Code.ToString();
            }
            else
                    if (Code < 1000)
            {
                return Code.ToString();
            }
            return "";
        }

        public static string ChuanHoaMaCuoi(string code)
        {
            return code.Split(' ')[0];
        }

        #endregion



        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ConnectEntity.Connection.CloseConn();
           Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HidePicture()
        {
            dock.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox9.Hide();
            searchBt.Hide();
            dataBt.Hide();
            reportBt.Hide();
            changeBt.Hide();
            creator.Hide();
            backPic.Show();

        }
        private void ShowPicture()
        {
            dock.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            pictureBox4.Show();
            pictureBox5.Show();
            pictureBox9.Show();
            searchBt.Show();
            dataBt.Show();
            reportBt.Show();
            changeBt.Show();
            creator.Show();
            backPic.Hide();
        }

        public void ExcuteCommand(string command)
        {
            SqlCommand cmd = new SqlCommand(command, ConnectEntity.Connection.Connection);
            cmd.ExecuteNonQuery();
        }

        private void backPic_Click(object sender, EventArgs e)
        {
            ShowPicture();

            if (searchControl1 != null && searchControl1.Visible == true)
            {
                searchControl1.Dispose();
                searchControl1 = new SearchControl();
                searchControl1.BackColor = System.Drawing.Color.Transparent;
                searchControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                searchControl1.Location = new System.Drawing.Point(66, 117);
                searchControl1.Name = "searchControl1";
                searchControl1.Size = new System.Drawing.Size(856, 523);
                searchControl1.TabIndex = 16;
                searchControl1.Visible = false;
                this.Controls.Add(searchControl1);
            }
            reportControl1.Visible = false;
            ruleChangeControl1.Visible = false;
            aboutControl1.Visible = false;
            if(saleControl1 != null)
            {
                saleControl1.Dispose();
            }
        }

        private void btSwitch_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lgForm = new LoginForm();
            lgForm.Show();
        }

        private void creator_Click(object sender, EventArgs e)
        {
            HidePicture();
            aboutControl1.Visible = true;
            aboutControl1.BringToFront();
        }

        private void aboutControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // image = new Bitmap(@"C:\Users\Admin\Downloads\Vemaybay-master\Vemaybay-master\Airline\Resources\background.gif");
            //Console.WriteLine(Path.Combine(Application.StartupPath, @"..\..\Resources\background.gif"));
            this.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\background.png"));
                
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void TaskBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

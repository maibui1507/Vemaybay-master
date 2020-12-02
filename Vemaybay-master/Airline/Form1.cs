﻿using System;
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

namespace Airline
{
    public partial class Form1 : Form
    {
        #region INIT

        SearchControl searchControl1;
        ReportControl reportControl1=new ReportControl();
        RuleChangeControl ruleChangeControl1;
        static public SaleControl saleControl1;



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
        private bool CheckUser(string s)
        { 
            if (s == "True")
            {
                return true;
            }
            return false;
        }

        private void dataBt_Click(object sender, EventArgs e)
        {
            
            if (CheckUser(LoginForm.loaiNguoiDung))
            {

                openFileDialog1.Filter = "Excel | *.xlsx; *.xls| All File (*.*)|*.*";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    //Console.WriteLine(openFileDialog1.FileName);
                    // tạo đối tượng excel
                    Excel.Application xlApp = new Excel.Application();
                    LoginModel.Connection.OpenConn();
                    try
                    {
                        Excel.Workbook workbook = xlApp.Workbooks.Open(openFileDialog1.FileName);
                        for (int i = 1; i < 4; i++)
                        {
                            // mở tệp
                            
                            Excel.Workbook xlWorkbook = workbook;
                            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[i];
                            Excel.Range range = xlWorksheet.UsedRange;
                            object[,] valueArray = (object[,])range.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
                            int row = valueArray.GetLength(0);
                            string command = "";
                            switch (i)
                            {
                                case 1: // SANBAY    
                                    try
                                    {
                                        for (int j = 2; j <= row; j++)
                                        {
                                            string maSanBay = valueArray[j, 1].ToString();
                                            string tenSanBay = valueArray[j, 2].ToString();
                                            string tinh = valueArray[j, 3].ToString();
                                            string quocGia = valueArray[j, 4].ToString();
                                            Console.WriteLine(maSanBay + tenSanBay + tinh + quocGia);
                                            command = "INSERT INTO SANBAY VALUES("
                                             + "'" + maSanBay + "'" + ", "
                                             + "N'" + tenSanBay + "'" + ", "
                                             + "N'" + tinh + "'" + ", " + "N'" + quocGia + "'" + ")";
                                            ExcuteCommand(command);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                        return;
                                    }
                                    break;
                                case 2: // CHUYENBAY
                                    try
                                    {
                                        for (int j = 2; j <= row; j++)
                                        {
                                            if (valueArray[j, 1] == null)
                                            {
                                                break;
                                            }
                                            string maChuyenBay = valueArray[j, 1].ToString();
                                            long giaVeHang1 = long.Parse(valueArray[j, 2].ToString());
                                            long giaVeHang2 = long.Parse(valueArray[j, 3].ToString());
                                            string sanBayDi = valueArray[j, 4].ToString();
                                            string sanBayDen = valueArray[j, 5].ToString();
                                            string ngayBay = valueArray[j, 6].ToString();
                                            string gioBay = valueArray[j, 13].ToString();
                                            int thoiGianBay = int.Parse(valueArray[j, 8].ToString());
                                            int hang1 = int.Parse(valueArray[j, 9].ToString());
                                            int hang2 = int.Parse(valueArray[j, 10].ToString());
                                            int hang1conlai = int.Parse(valueArray[j, 11].ToString());
                                            int hang2conlai = int.Parse(valueArray[j, 12].ToString());

                                            Console.WriteLine(maChuyenBay + giaVeHang1 + " " + giaVeHang2 + sanBayDi + sanBayDen + ngayBay);


                                            command = "insert into chuyenbay values("
                                             + "'" + maChuyenBay + "'" + ", "
                                             + giaVeHang2 + ", " + giaVeHang1 + ", " + "'" + sanBayDi + "'" + ", "
                                             + "'" + sanBayDen + "'" + ", " + "'" + ngayBay + "'" + ", "
                                             + "'" + gioBay + "'" + ", " + thoiGianBay + ", " + hang1 + ", "
                                             + hang2 + ", " + hang1conlai + ", " + hang2conlai + ")";
                                            ExcuteCommand(command);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                        return;
                                    }
                                    break;
                                case 3: // SANBAYTRUNGGIAN
                                    try
                                    {
                                        for (int j = 2; j <= row; j++)
                                        {
                                            string chuyenBay = valueArray[j, 1].ToString();
                                            string sanbay = valueArray[j, 2].ToString();
                                            int thoiGianDung = int.Parse(valueArray[j, 3].ToString());
                                            command = "INSERT INTO SANBAYTRUNGGIAN VALUES("
                                             + "'" + chuyenBay + "'" + ", "
                                             + "'" + sanbay + "'" + ", "
                                             + thoiGianDung + ")";
                                            ExcuteCommand(command);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                        return;
                                    }
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                    searchControl1.LoadData();
                    MessageBox.Show("Data update successful !");

                }
                else
                {
                    MessageBox.Show("No file was selected !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("You don't have permission !");
            }
            LoginForm.Connection.CloseConn();

        }

        private void reportBt_Click(object sender, EventArgs e)
        {
            if (CheckUser(LoginForm.loaiNguoiDung))
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
            if (CheckUser(LoginForm.loaiNguoiDung))
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
            LoginForm.Connection.CloseConn();
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
            LoginForm.Connection.Connection.Close();
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
            SqlCommand cmd = new SqlCommand(command, LoginForm.Connection.Connection);
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
            this.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\background.gif"));
                
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void TaskBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

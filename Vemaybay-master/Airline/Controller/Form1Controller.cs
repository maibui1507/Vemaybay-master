using Airline.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Airline.Model;
namespace Airline.Controller
{
    class Form1Controller
    {
        SearchControl searchControl1;
        public Form1Model form1Model = new Form1Model();
        public bool CheckUser(string s)
        {
            if (s == "True")
            {
                return true;
            }
            return false;
        }
        public void Update_DB(OpenFileDialog openFileDialog1)
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
                    ConnectEntity.Connection.OpenConn();
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
                                            form1Model.Update_Sanbay(maSanBay,tenSanBay,tinh,quocGia);
                                            form1Model.ExcuteCommand(form1Model.command);
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


                                            form1Model.Update_ChuyenBay(maChuyenBay, giaVeHang1, giaVeHang2, sanBayDi,sanBayDen,
                                                ngayBay,gioBay,thoiGianBay,hang1,hang2,hang1conlai,hang2conlai);
                                            form1Model.ExcuteCommand(form1Model.command);
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
                                            form1Model.Update_SanBayTrungGian(chuyenBay, sanbay, thoiGianDung);
                                            form1Model.ExcuteCommand(form1Model.command);
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
                    //searchControl1.LoadData();
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
            ConnectEntity.Connection.CloseConn();

        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Airline
{
    public class ConnectToSQL
    {
        #region Available
        public SqlConnection Conn { get; set; }
       
        private SqlCommand CMD;

        public SqlCommand CMD1 { get => CMD; set => CMD = value; }
        public SqlConnection Connection { get { return Conn; } }


        public string error;
        public string Error { get => error; set => error = value; }
        string strCon;
        #endregion

        #region Constructor
        public ConnectToSQL()
        {
            //string path = System.IO.Path.GetFullPath(Environment.CurrentDirectory);
            //string databaseName = "AIRLINE.mdf";
            //strCon = @"Data Source=(localdb)\mssqllocaldb;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True";;
            strCon = @"Data Source=DESKTOP-EKOKVTF\SQLEXPRESS;Initial Catalog=AIRLINE;Integrated Security=True";
            Conn = new SqlConnection(strCon);
        }
        #endregion

        #region Methods
        public bool OpenConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;

        }
        public bool CloseConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
        #endregion




    }
}

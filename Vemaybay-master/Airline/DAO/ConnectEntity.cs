using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.Model;
namespace Airline.DAO
{
    public class ConnectEntity
    {
        public static ConnectToSQL connection = new ConnectToSQL();
        internal static ConnectToSQL Connection { get => connection; set => connection = value; }
        public ConnectEntity()
        {
            Connection.OpenConn();
            
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
namespace Connect_Oracle
{
    public class Database
    {
           public static OracleConnection Conn;
        private static OracleConnection connSys;

           public static string Host;
           public static string Port;
           public static string Sid;
           public static string User;
           public static string Password;

           public static void Set_database(string host, string port, string sid, string user, string pass)
           {
               Database.Host = host;
               Database.Port = port;
               Database.Sid = sid;
               Database.User = user;
               Database.Password = pass;
           }
           public static bool Connect()
           {
               string connsys = "";
                try
                {
                    if(User.ToUpper().Equals("SYS"))
                    {
                        connsys = ";DBA Privilege = SYSDBA";
                    }
                    string connString = "Data Source = (DESCRIPTION=(ADDRESS=(PROTOCOL = TCP)(HOST = " + Host + ")(PORT = " + Port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + Sid + ")));User ID = " + User + "; Password = " + Password + connsys;

                    Conn = new OracleConnection();
                    Conn.ConnectionString = connString;
                    Conn.Open();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
           }

        public static void Close_Connect()
        {
            if (Conn.State.ToString().Equals("Open"))
            {
                Conn.Close();
            }
        }

        public static bool ConnectSys()
        {
            try
            {
                string connString = $@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={Host})(PORT={Port}))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={Sid})));User ID=SYS;Password=sys;DBA Privilege=SYSDBA";


                connSys = new OracleConnection();
                connSys.ConnectionString = connString;
                connSys.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại chuỗi kết nối!!!");
                return false;
            }
        }
        public static OracleConnection Get_Connect()
        {
            if (Conn == null || Conn.State != System.Data.ConnectionState.Open)
            {
                Connect(); 
            }
            return Conn;
        }

        public static OracleConnection Get_ConnectSys()
        {
            if (connSys == null || connSys.State == ConnectionState.Closed || connSys.State == ConnectionState.Broken)
            {
                ConnectSys();
            }
            if (connSys.State == ConnectionState.Closed)
            {
                connSys.Open();
            }
            return connSys;
        }


        public static void Close_ConnectSYS()
        {
            if (connSys.State.ToString().Equals("Open"))
            {
                connSys.Close();
            }
        }
        public static string Get_Status(string user)
        {
            try
            {
                string Function = "fun_account_status"; 
                OracleCommand cmd = new OracleCommand();
                OracleConnection cnn = Get_ConnectSys();
                cmd.Connection = cnn;
                cmd.CommandText = Function;
                cmd.CommandType = CommandType.StoredProcedure; // Hoặc CommandType.Text nếu là function

                // Tham số output
                OracleParameter resultParam = new OracleParameter();
                resultParam.ParameterName = "@Result"; // Tên tham số output trong stored procedure
                resultParam.OracleDbType = OracleDbType.Varchar2;
                resultParam.Size = 100;
                resultParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(resultParam);

                // Tham số input
                OracleParameter userName = new OracleParameter();
                userName.ParameterName = "@User";  // Tên tham số input trong stored procedure
                userName.OracleDbType = OracleDbType.Varchar2;
                userName.Value = user.ToUpper(); 
                userName.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(userName);

                cmd.ExecuteNonQuery();


                if (resultParam.Value != DBNull.Value)
                {
                    OracleString ret = (OracleString)resultParam.Value; // Lấy giá trị từ tham số output
                    string s = ret.ToString();
                    return s;
                }
            }
            catch (Exception ex)
            {
                return ""; 
            }
            return ""; 

        }
    }
}

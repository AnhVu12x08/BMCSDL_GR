using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using System.Data;
namespace Connect_Oracle
{
    public class MHOracle
    {
        OracleConnection conn;

        public MHOracle(OracleConnection conn)
        {
            this.conn = conn;
        }

        public string EncryptCaesar_Func(string PlainText, int key)
        {
            try
            {
                string Function = "encryptCaesarCipher";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Function;
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter resultParam = new OracleParameter();
                resultParam.ParameterName = "@Result";
                resultParam.OracleDbType = OracleDbType.Varchar2;
                resultParam.Size = 100;
                resultParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(resultParam);
                OracleParameter str = new OracleParameter();
                str.ParameterName = "@str";
                str.OracleDbType = OracleDbType.Varchar2;
                str.Value = PlainText;
                str.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(str);

                OracleParameter k = new OracleParameter();
                k.ParameterName = "@k";
                k.OracleDbType = OracleDbType.Int32;
                k.Value = key;
                k.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(k);

                cmd.ExecuteNonQuery();

                string s = "null";
                if (resultParam.Value != DBNull.Value)
                {
                    OracleString ret = (OracleString)resultParam.Value;
                    s = ret.ToString();
                }

                return s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }

            return null;
        }

        public string DecryptCaesar_Func(string EncryptedText, int key)
        {
            try
            {
                string Function = "decryptCaesarCipher";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Function;
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter resultParam = new OracleParameter();
                resultParam.ParameterName = "@Result";
                resultParam.OracleDbType = OracleDbType.Varchar2;
                resultParam.Size = 100;
                resultParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(resultParam);

                OracleParameter str = new OracleParameter();
                str.ParameterName = "@str";
                str.OracleDbType = OracleDbType.Varchar2;
                str.Value = EncryptedText;
                str.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(str);

                OracleParameter k = new OracleParameter();
                k.ParameterName = "@k";
                k.OracleDbType = OracleDbType.Int32;
                k.Value = key;
                k.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(k);
                cmd.ExecuteNonQuery();

                string s = "null";
                if (resultParam.Value != DBNull.Value)
                {
                    OracleString ret = (OracleString)resultParam.Value;
                    s = ret.ToString();
                }

                return s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }

            return null;
        }

        public string EncryptCaesar_Proc(string PlainText, int key)
        {
            try
            {
                string Procedure = "encryptCaesarCipherProc";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Procedure;
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter str = new OracleParameter();
                str.ParameterName = "@str";
                str.OracleDbType = OracleDbType.Varchar2;
                str.Value = PlainText;
                str.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(str);

                OracleParameter k = new OracleParameter();
                k.ParameterName = "@k";
                k.OracleDbType = OracleDbType.Int32;
                k.Value = key;
                k.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(k);

                OracleParameter kq = new OracleParameter();
                kq.ParameterName = "@enc";
                kq.OracleDbType = OracleDbType.Varchar2;
                kq.Size = 100;
                kq.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(kq);

                cmd.ExecuteNonQuery();

                return kq.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }

            return null;
        }

        public string DecryptCaesar_Proc(string EncryptedText, int key)
        {
            try
            {
                string Function = "decryptCaesarCipherProc";

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = Function;
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter str = new OracleParameter();
                str.ParameterName = "@dec";
                str.OracleDbType = OracleDbType.Varchar2;
                str.Value = EncryptedText;
                str.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(str);

                OracleParameter k = new OracleParameter();
                k.ParameterName = "@k";
                k.OracleDbType = OracleDbType.Int32;
                k.Value = key;
                k.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(k);

                OracleParameter kq = new OracleParameter();
                kq.ParameterName = "@dec";
                kq.OracleDbType = OracleDbType.Varchar2;
                kq.Size = 100;
                kq.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(kq);

                cmd.ExecuteNonQuery();

                return kq.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }

            return null;
        }


    }

}


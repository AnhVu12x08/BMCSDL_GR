using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Connect_Oracle
{
    public partial class DangNhap : Form
    {
        internal static OracleConnection conn;

        public DangNhap()
        {
            InitializeComponent();
            CenterToScreen();
        }


        public bool CheckTextBoxes(string host, string port, string sid, string user, string password)
        {
            if (string.IsNullOrEmpty(host))
            {
                MessageBox.Show("Host is required.");
                txt_host.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(port))
            {
                MessageBox.Show("Port is required.");
                txt_port.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(sid))
            {
                MessageBox.Show("SID is required.");
                txt_sid.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Username is required.");
                txt_user.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.");
                txt_pass.Focus();
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = txt_host.Text;
            string port = txt_port.Text;
            string sid = txt_sid.Text;
            string user = txt_user.Text;
            string pass = txt_pass.Text;

            if(CheckTextBoxes(host,port,sid,user,pass))
            {
                Database.Set_database(host, port, sid, user, pass);


                if(Database.Connect())
                {
                    OracleConnection c = Database.Get_Connect();
                    if (user == "sys" || user == "bmcsdl_1")
                    {
                        this.Hide();
                        LuaChon lc = new LuaChon();
                        lc.Show();
                    }
                    else
                    {
                        this.Hide();
                        QLNV qlnv = new QLNV();
                        qlnv.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
        }


        private void clickDHAC(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy RegisterForm = new DangKy();
            RegisterForm.Show();
            this.Hide();
        }
    }
}

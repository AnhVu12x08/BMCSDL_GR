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
            txt_pass.UseSystemPasswordChar = !cb_pass.Checked;
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

        void Check_Status(string user)
        {
            string status = Database.Get_Status(user);

            if (status.Equals("LOCKED") || status.Equals("LOCKED(TIMED)"))
            {
                MessageBox.Show("Tài khoản bị khóa");
            }
            
            else if (status.Equals(""))
            {
                MessageBox.Show("Tài khoản không tồn tại");
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!\nXem lại thông tin đăng nhập: UserName, Password");
            }
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
                        QLKH qlnv = new QLKH();
                        qlnv.Show();
                    }

                }
                else
                {
                    Check_Status(user);
                    return;
                    //MessageBox.Show("Login Failed!");
                }
            }
        }


        private void clickDHAC(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy RegisterForm = new DangKy();
            RegisterForm.Show();
            this.Hide();
        }

        private void cb_pass_CheckedChanged(object sender, EventArgs e)
        {
            txt_pass.UseSystemPasswordChar = !cb_pass.Checked;
        }
    }
}

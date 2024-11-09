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
        public DangNhap()
        {
            InitializeComponent();
            CenterToScreen();
        }

       
        bool Check_Textbox(string host, string port, string sid, string user, string pass)
        {
               if(host == "")
                {
                    MessageBox.Show("Chưa điền thông tin Host");
                    txt_host.Focus();
                    return false;
                }
        else if (port == "")
        {
            MessageBox.Show("Chưa điền thông tin Port");
            txt_port.Focus();
            return false;
        }
        else if (sid == "")
        {
            MessageBox.Show("Chưa điền thông tin Sid");
            txt_sid.Focus();
            return false;
        }
        else if (user == "")
        {
            MessageBox.Show("Chưa điền thông tin UserName");
            txt_user.Focus();
            return false;
        }
        else if (pass == "")
        {
            MessageBox.Show("Chưa điền thông tin Password ");
            txt_pass.Focus();
            return false;
        }
        else
         {
            return true;
         }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = txt_host.Text;
            string port = txt_port.Text;
            string sid = txt_sid.Text;
            string user = txt_user.Text;
            string pass = txt_pass.Text;

            if(Check_Textbox(host,port,sid,user,pass))
            {
                Database.Set_database(host, port, sid, user, pass);


                if(Database.Connect())
                {
                    OracleConnection c = Database.Get_Connect();
                    if (user == "sys" || user == "bmcsdl_1")
                    {
                        this.Hide();
                        Phanquyen pq = new Phanquyen();
                        pq.Show();
                        MessageBox.Show("Đăng nhập thành công\nServerVersion: " + c.ServerVersion);
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công\nServerVersion: " + c.ServerVersion);
                    }

                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_Oracle
{
    public partial class LuaChon : Form
    {
        public LuaChon()
        {
            InitializeComponent();
        }

        private void clickManageUsers(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyNhanVien qly = new QuanLyNhanVien();
            qly.Show();
        }

        private void clickPriviManage(object sender, EventArgs e)
        {
            this.Hide();
            Phanquyen pq = new Phanquyen();
            pq.Show();
        }

        private void clickLogout(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
        }
    }
}

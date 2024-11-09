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
using Oracle.ManagedDataAccess.Types;

namespace Connect_Oracle
{
    public partial class Phanquyen : Form
    {
        public Phanquyen()
        {
            InitializeComponent();
        }

        //select all users from database and add it to combobox
        private void AddGranter()
        {
            string query = "SELECT USERNAME FROM ALL_USERS";
            OracleCommand cmd = new OracleCommand(query, DangNhap.conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbbGranterSys.Items.Add(dr[0]);
            }
        }


        private void clickBack(object sender, EventArgs e)
        {
            this.Hide();
            LuaChon lc = new LuaChon();
            lc.Show();
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Connect_Oracle
{
    public partial class QuanLyNguoiDung : Form
    {
        public QuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void clickBack(object sender, EventArgs e)
        {
            this.Hide();
            LuaChon lc = new LuaChon();
            lc.Show();
        }

        private void ShowAllUsers(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if(connection != null)
                    {
                        using (OracleCommand cmd = new OracleCommand("SELECT * FROM ALL_USERS", connection))
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dgvUsers.DataSource = dt;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not connected to the database!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}

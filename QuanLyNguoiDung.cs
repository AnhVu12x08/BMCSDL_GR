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
        OracleConnection conn;
        Profile Proc;

        public QuanLyNguoiDung()
        {
            InitializeComponent();
            CenterToScreen();
            conn = Database.Get_Connect();
            Proc = new Profile(conn);
            Load_Combobox();
        }

        void Load_Combobox()
        {
            try
            {
                DataTable read = Proc.GetName_Profile();

                foreach (DataRow r in read.Rows)
                {
                    cbbSys.Items.Add(r[0]);
                }
                cbbSys.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }
            
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
                    if (connection != null)
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

        private void cbbSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbSys.SelectedIndex;
            string profile = cbbSys.SelectedItem.ToString();
            dgvUsers.DataSource = Proc.Get_Profile(profile);
        }
    }
}

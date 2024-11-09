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
            string connectionString = "User Id=BMCSDL_1;Password=123;Data Source=localhost:1521/orcl";

            try // Move try-catch outside the using block
            {
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    con.Open();
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT username FROM all_users"; // Consistent spacing

                        listboxUsers.BeginUpdate(); // Prevent flickering during update
                        listboxUsers.Items.Clear();

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listboxUsers.Items.Add(reader.GetString(0));
                            }
                        }

                        listboxUsers.EndUpdate(); // Re-enable updates and redraw
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // String interpolation for slightly cleaner code
            }
        }
    }
}

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
            AddGranter("cbbGranterSys");
            AddGranter("cbbGranteeSys");
            AddGranter("cbbGranterObj");
            AddGranter("cbbGranteeObj");
            cbbGranterSys.Text = "SYS";
        }

        //select all users from database and add it to combobox
        private void AddGranter(string componentName)
        {
            // Get the ComboBox control based on its name
            ComboBox comboBox = this.Controls.Find(componentName, true).FirstOrDefault() as ComboBox;


            if (comboBox == null)
            {
                MessageBox.Show($"Error: ComboBox '{componentName}' not found.");
                return; 
            }

            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        using (OracleCommand cmd = new OracleCommand("SELECT USERNAME FROM ALL_USERS", connection))
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                comboBox.Items.Add(dr[0].ToString()); 
                            }
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

        //show table of chosen granter and show to obbject combobox
        private void cbbGranterSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGranterObj.SelectedItem == null) return;


            string granter = cbbGranterObj.SelectedItem.ToString();
            cbbObjectObj.Items.Clear();


            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        // Use UPPER() in the query as well for case-insensitive comparison
                        string query = $"SELECT TABLE_NAME FROM ALL_TABLES WHERE UPPER(OWNER) = '{granter}'";
                        using (OracleCommand cmd = new OracleCommand(query, connection))
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            if (!dr.HasRows)
                            {
                                MessageBox.Show($"User '{granter}' does not own any tables.");
                            }
                            else
                            {
                                while (dr.Read())
                                {
                                    cbbObjectObj.Items.Add(dr[0].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not connected to the database!");
                    }
                }
            }
            catch (OracleException ex) // Catch specific Oracle exceptions
            {
                MessageBox.Show($"Oracle Error: {ex.Message}");
            }
            catch (Exception ex) // Catch other exceptions
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void clickBack(object sender, EventArgs e)
        {
            this.Hide();
            LuaChon lc = new LuaChon();
            lc.Show();
        }

        //grant system privilege
        private void clickPrivilegeSys(object sender, EventArgs e)
        {
            if (cbbGranterSys.SelectedItem == null || cbbGranteeSys.SelectedItem == null || checklistObjectSys.SelectedItem == null)
            {
                MessageBox.Show("Please select all fields.");
                return;
            }

            string granter = cbbGranterSys.SelectedItem.ToString();
            string grantee = cbbGranteeSys.SelectedItem.ToString();
            string privilege = checklistObjectSys.SelectedItem.ToString();

            try
            {
                using(OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        string query = $"GRANT {privilege} TO {grantee}";
                        using (OracleCommand cmd = new OracleCommand(query, connection))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"Granted {privilege} to {grantee} successfully.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not connected to the database!");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
    }
}

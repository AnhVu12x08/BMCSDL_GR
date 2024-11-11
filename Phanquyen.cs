using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
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
            AddGranter("cbbGranteeSys");
            AddGranter("cbbGranterObj");
            AddGranter("cbbGranteeObj");
            AddGranter("cbbObjectObj");
            AddGranter("cbbUserRevokeSys");
            cbbGranterObj.Text = "BMCSDL_1";
        }

        private void AddGranter(string componentName)
        {
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
            if (cbbGranteeSys.SelectedItem == null || checklistObjectSys.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select all fields.");
                return;
            }

            string grantee = cbbGranteeSys.SelectedItem.ToString();

            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        foreach (string privilege in checklistObjectSys.CheckedItems.OfType<string>())
                        {
                            string query = $"GRANT {privilege} TO {grantee}";
                            using (OracleCommand cmd = new OracleCommand(query, connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show($"Granted privileges to {grantee} successfully.");

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


        //revoke system privilege
        private void btnRevokeSys_Click(object sender, EventArgs e)
        {
            if (cbbUserRevokeSys.SelectedItem == null || clbPriviRevokeSys.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select all fields.");
                return;
            }

            try
            {
                using(OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        string user = cbbUserRevokeSys.SelectedItem.ToString();
                        foreach (string privilege in clbPriviRevokeSys.CheckedItems.OfType<string>())
                        {
                            string query = $"REVOKE {privilege} FROM {user}";
                            using (OracleCommand cmd = new OracleCommand(query, connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show($"Revoked privileges from {user} successfully.");
                        clbPriviRevokeSys.Items.Clear();
                        cbbPriviRevokeSys_Click(sender, e);
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

        

        //list all user privilege to checklistbox
        private void cbbPriviRevokeSys_Click(object sender, EventArgs e)
        {
            if (cbbUserRevokeSys.SelectedItem == null) return;

            string user = cbbUserRevokeSys.SelectedItem.ToString();
            clbPriviRevokeSys.Items.Clear();

            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        string query = $"SELECT PRIVILEGE FROM DBA_SYS_PRIVS WHERE GRANTEE = '{user}'";
                        using (OracleCommand cmd = new OracleCommand(query, connection))
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            if (!dr.HasRows)
                            {
                                MessageBox.Show($"User '{user}' does not have any system privileges.");
                            }
                            else
                            {
                                while (dr.Read())
                                {
                                    clbPriviRevokeSys.Items.Add(dr[0].ToString());
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

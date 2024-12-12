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
    public partial class QuanLyNhanVien : Form
    {
        OracleConnection conn;
        Profile Proc;
        private int decryptionKey = 9;
        public QuanLyNhanVien()
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
                using (OracleConnection connection = Database.Get_ConnectSys())
                {
                    if (connection != null)
                    {
                        MHOracle mh = new MHOracle(connection);



                        string sql = $@"
                                Select Ma_Nhanvien, Username, 
                                decryptCaesarCipher(PW, {decryptionKey}) AS DECRYPTED_PW, -- Giải mã password
                                decryptCaesarCipher(SDT_NV, {decryptionKey}) AS DECRYPTED_SDT, -- Giải mã SDT
                                decryptCaesarCipher(EMAIL_NV, {decryptionKey}) AS DECRYPTED_EMAIL -- Giải mã email
                            From Bmcsdl_1.Nhanvien;";

                        using (OracleCommand cmd = new OracleCommand(sql, connection))
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

        private void ShowAccountStatus(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection connection = Database.Get_ConnectSys())
                {
                    if (connection != null)
                    {
                        using (OracleCommand cmd = new OracleCommand("SELECT * FROM View_Users", connection))
                        {
                            using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dgvAccountSt.DataSource = dt;
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

        private void cbbSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbSys.SelectedIndex;
            string profile = cbbSys.SelectedItem.ToString();
            
            dgvUsers.DataSource = Proc.Get_Profile(profile);

            ShowAccountStatus(sender, e);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (cbbSys.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            string username = cbbSys.SelectedItem.ToString();

            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        using (OracleTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {

                                using (OracleCommand cmdDeleteNhanVien = new OracleCommand("DELETE FROM BMCSDL_1.NHANVIEN WHERE USERNAME = :username", connection))
                                {
                                    cmdDeleteNhanVien.Transaction = transaction;
                                    cmdDeleteNhanVien.Parameters.Add(new OracleParameter(":username", username));
                                    int rowsAffected = cmdDeleteNhanVien.ExecuteNonQuery();

                                    if (rowsAffected == 0)
                                    {

                                        MessageBox.Show($"User '{username}' not found in NHANVIEN table.");
                                        transaction.Rollback();
                                        return;
                                    }

                                }


                                using (OracleCommand cmdDropUser = new OracleCommand($"DROP USER {username} CASCADE", connection))
                                {
                                    cmdDropUser.Transaction = transaction;

                                    try
                                    {
                                        cmdDropUser.ExecuteNonQuery();

                                    }
                                    catch (OracleException ex)
                                    {

                                        if (ex.Number == 1918)
                                        {

                                            MessageBox.Show($"User '{username}' does not exist in the database");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error dropping user from the database: " + ex.Message);

                                        }
                                        transaction.Rollback();
                                        return;

                                    }

                                }
                                transaction.Commit();

                                MessageBox.Show($"User '{username}' deleted successfully.");

                                cbbSys.Items.Remove(username);
                                if (cbbSys.Items.Count > 0)
                                {
                                    cbbSys.SelectedIndex = 0;
                                    cbbSys_SelectedIndexChanged(null, null);
                                }
                                else
                                {
                                    dgvUsers.DataSource = null;
                                }
                            }


                            catch (Exception innerEx)
                            {
                                if (transaction != null) transaction.Rollback();

                                MessageBox.Show($"Error deleting user from NHANVIEN: {innerEx.Message}");
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            using (DangKy dangKyForm = new DangKy())
            {
                if (dangKyForm.ShowDialog() == DialogResult.OK)
                {

                    RefreshData();

                }
            }
        }

        private void RefreshData()
        {
            try
            {
                cbbSys.Items.Clear();
                Load_Combobox();
                cbbSys_SelectedIndexChanged(null, null);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error refreshing data: " + ex.Message);
            }
        }
        private ChangeIF_User modifyForm;
        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (cbbSys.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to modify.");
                return;
            }

            string selectedUsername = cbbSys.SelectedItem.ToString();

            if (modifyForm == null)
            {
                modifyForm = new ChangeIF_User();
                modifyForm.FormClosed += (s, args) => modifyForm = null;
            }

            modifyForm.SelectedUsername = selectedUsername;
            modifyForm.LoadUserData(selectedUsername);
            modifyForm.Show();
            this.Hide();

        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = Database.Get_ConnectSys())
            {
                if (connection != null)
                {
                    if (dgvAccountSt.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please select a user to unlock.");
                        return;
                    }
                    string username = dgvAccountSt.SelectedRows[0].Cells["Username"].Value.ToString();
                    using (OracleCommand cmd = new OracleCommand($"ALTER USER {username} ACCOUNT UNLOCK", connection))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"User '{username}' unlocked successfully.");
                            ShowAccountStatus(sender, e);
                        }
                        catch (OracleException oex)
                        {
                            MessageBox.Show("Oracle Error unlocking user " + username + ": \n" + oex.Message);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not connected to the database!");
                }
            }
        }



        private void dgvAccountSt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                btnUnlock.Enabled = true;

            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = Database.Get_ConnectSys())
            {
                if (connection != null)
                {
                    if (dgvAccountSt.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please select a user to lock.");
                        return;
                    }
                    string username = dgvAccountSt.SelectedRows[0].Cells["Username"].Value.ToString();
                    using (OracleCommand cmd = new OracleCommand($"ALTER USER {username} ACCOUNT LOCK", connection))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"User '{username}' locked successfully.");
                            ShowAccountStatus(sender, e);
                        }
                        catch (OracleException oex)
                        {
                            MessageBox.Show("Oracle Error locking user " + username + ": \n" + oex.Message);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not connected to the database!");
                }
            }
        }
    }
}
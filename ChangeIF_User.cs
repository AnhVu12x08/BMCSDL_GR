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
    public partial class ChangeIF_User : Form
    {
        public string SelectedUsername { get; set; }
        public ChangeIF_User()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void ChangeIF_User_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedUsername))
            {

                lblUsername.Text = SelectedUsername;
                LoadUserData(SelectedUsername); 
            }
        }

        public void LoadUserData(string username)
        {
            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        using (OracleCommand cmd = new OracleCommand("SELECT * FROM BMCSDL_1.NHANVIEN WHERE USERNAME = :username", connection))
                        {
                            cmd.Parameters.Add(new OracleParameter(":username", username));
                            using (OracleDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    lblUsername.Text += reader["username"]?.ToString();
                                    txtPhone.Text = reader["SDT_NV"]?.ToString();
                                    txtEmail.Text = reader["EMAIL_NV"]?.ToString();
                                    txtPassword.Text = reader["PW"]?.ToString();
                                    txtRePassword.Text = reader["PW"]?.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not connected to database");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }
        }


        private void btn_submit_Click(object sender, EventArgs e)
        {
            string username = lblUsername.Text;
            string newPhone = txtPhone.Text;
            string newEmail = txtEmail.Text;
            string newPassword = txtPassword.Text;
            string retypedPassword = txtRePassword.Text;

            
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please select a username.");
                return;
            }
            if (string.IsNullOrEmpty(newPhone))
            {
                MessageBox.Show("Phone number cannot be empty.");
                return;
            }
            if (string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("Email cannot be empty.");
                return;
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }
            if (newPassword != retypedPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

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
                                // Update table NHANVIEN
                                using (OracleCommand cmdUpdateNhanVien = new OracleCommand("UPDATE BMCSDL_1.NHANVIEN SET SDT_NV = :phone, EMAIL_NV = :email, PW = :password WHERE USERNAME = :username", connection))
                                {
                                    cmdUpdateNhanVien.Transaction = transaction;
                                    cmdUpdateNhanVien.Parameters.Add(new OracleParameter(":phone", newPhone));
                                    cmdUpdateNhanVien.Parameters.Add(new OracleParameter(":email", newEmail));
                                    cmdUpdateNhanVien.Parameters.Add(new OracleParameter(":password", newPassword)); 
                                    cmdUpdateNhanVien.Parameters.Add(new OracleParameter(":username", username));
                                    cmdUpdateNhanVien.ExecuteNonQuery();
                                }

                                // Change pass on user in Oracle
                                using (OracleCommand cmdAlterUser = new OracleCommand($"ALTER USER {username} IDENTIFIED BY {newPassword}", connection))
                                {

                                    cmdAlterUser.Transaction = transaction;
                                    cmdAlterUser.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("User information updated successfully.");



                            }
                            catch (Exception innerEx)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error updating user information: " + innerEx.Message);


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

                MessageBox.Show("Error updating user information: " + ex.Message);

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyNhanVien ql = new QuanLyNhanVien();
            ql.Show();
        }
    }
}
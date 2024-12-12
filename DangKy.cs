using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;


namespace Connect_Oracle
{
    public partial class DangKy : Form
    {
        public static OracleConnection conn;
        private int encryptionKey = 9;
        public DangKy()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string retypePassword = txtRePassword.Text;
            string staffID = RandomNumber().ToString();
            

            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(retypePassword))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (password != retypePassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (IsPhoneNumber(phone) == false)
            {
                MessageBox.Show("Invalid phone number.");
                return;
            }

            if (IsValidEmail(email) == false)
            {
                MessageBox.Show("Invalid email address.");
                return;
            }

            if (IsValidPassword(password) == false)
            {
                MessageBox.Show("Password must contain at least 8 characters, 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character.");
                return;
            }


            string connectionString = "User Id=BMCSDL_1;Password=123;Data Source=localhost:1521/orcl";

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    MHOracle mh = new MHOracle(conn);

                    using (OracleTransaction trans = conn.BeginTransaction()) 
                    {
                        try
                        {
                            // Encrypt using Caesar cipher (using MHOracle)
                            string encryptedPassword = mh.EncryptCaesar_Func(password, encryptionKey);
                            string encryptedPhone = mh.EncryptCaesar_Func(phone, encryptionKey);
                            string encryptedEmail = mh.EncryptCaesar_Func(email, encryptionKey);

                            // Create a new user
                            string createUserQuery = $"CREATE USER {username} IDENTIFIED BY {password}";
                            using (OracleCommand cmd = new OracleCommand(createUserQuery, conn))
                            {
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();
                            }

                            // Assign profile to the user
                            string assignProfileQuery = $"ALTER USER {username} PROFILE Mypassword";
                            using (OracleCommand cmd = new OracleCommand(assignProfileQuery, conn))
                            {
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();
                            }

                            // Grant privileges to the new user
                            string grantPrivilegesQuery = $"GRANT CREATE SESSION TO {username}";
                            using (OracleCommand cmd = new OracleCommand(grantPrivilegesQuery, conn)) 
                            {
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();
                            }

                            // Grant select on NGUOITHUE to new user 
                            string grantSelectNTQuery = $"GRANT SELECT ON BMCSDL_1.NGUOITHUE TO {username}";
                            using (OracleCommand cmd = new OracleCommand(grantSelectNTQuery, conn))
                            {
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();
                            }

                            // Grant select on DAT_PHONG to new user 
                            string grantSelectDPQuery = $"GRANT SELECT ON BMCSDL_1.DAT_PHONG TO {username}";
                            using (OracleCommand cmd = new OracleCommand(grantSelectDPQuery, conn))
                            {
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();
                            }
                           
                            // Insert the new user into the database
                            string insertNhanVienQuery = "INSERT INTO BMCSDL_1.nhanvien (MA_NHANVIEN, Username, PW, SDT_NV, EMAIL_NV) " +
                                                    "VALUES (:staffID, :username, :password, :phone, :email)";


                            using (OracleCommand cmd = new OracleCommand(insertNhanVienQuery, conn))
                            {
                                cmd.Transaction = trans;
                                cmd.Parameters.Add("staffID", OracleDbType.Varchar2).Value = staffID;
                                cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                                cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = encryptedPassword; 
                                cmd.Parameters.Add("phone", OracleDbType.Varchar2).Value = encryptedPhone; 
                                cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = encryptedEmail;
                                cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show("Account created successfully!");
                            ClearForm();
                            //this.DialogResult = DialogResult.OK;
                            //this.Close();
                            
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback(); 
                            MessageBox.Show($"Error creating account: {ex.Message}");
                        }
                    }
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        

        //random StaffID
        private int RandomNumber()
        {
            Random random = new Random();
            return random.Next(10,9999999);
        }

        //check phone number
        private static bool IsPhoneNumber(string number)
        {
            if(number.Length < 10 || number.Length > 10)
            {
                return false;
            }
            else
                return true;
        }

        //check email
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        //check password
        private bool IsValidPassword(string password)
        {
            Regex validateGuidRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return validateGuidRegex.IsMatch(password);
        }

       
        private void ClearForm()
        {
            txtUsername.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
        }


        private void DangKy_Load(object sender, EventArgs e)
        {

        }

        private void clickAHAAC(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangNhap loginForm = new DangNhap();
            loginForm.Show();
            this.Hide();
        }
    }
}

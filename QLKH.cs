using Oracle.ManagedDataAccess.Client;
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
    public partial class QLKH : Form
    {
        public QLKH()
        {
            InitializeComponent();
            LoadKhachHang();
        }

        private void LoadKhachHang()
        {
            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        string query = @"SELECT NT.MA_NGUOITHUE, NT.HOTEN_NT, NT.SDT, NT.EMAIL, DP.MA_DATPHONG, DP.NGAY_VAO, DP.NGAY_RA, DP.MA_PHONG
                                        FROM BMCSDL_1.NGUOITHUE NT
                                        LEFT JOIN BMCSDL_1.DAT_PHONG DP ON NT.MA_NGUOITHUE = DP.MA_NGUOITHUE";
                        using (OracleDataAdapter da = new OracleDataAdapter(query, connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvCus.DataSource = dt; 
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
                MessageBox.Show($"Error loading Customers: {ex.Message}");
            }
        }



       


        

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            using (Add_Customers addCustomersForm = new Add_Customers())
            {
                if (addCustomersForm.ShowDialog() == DialogResult.OK)
                {
                    LoadKhachHang();
                }
            }
        }



        private void btn_Delete_Click_1(object sender, EventArgs e)
        {

            if (dgvCus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {

                        //Lấy Ma_NguoiThue từ row được chọn
                        int maNguoiThue = Convert.ToInt32(dgvCus.SelectedRows[0].Cells["MA_NGUOITHUE"].Value);
                        using (OracleCommand cmd = new OracleCommand("DELETE FROM BMCSDL_1.NGUOITHUE WHERE MA_NGUOITHUE = :maNguoiThue", connection))
                        {
                            cmd.Parameters.Add(new OracleParameter(":maNguoiThue", maNguoiThue));
                            try
                            {
                                cmd.ExecuteNonQuery();
                                LoadKhachHang();//Refresh data sau khi xóa
                                MessageBox.Show("Khách hàng deleted successfully.");

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.GetBaseException().ToString());
                                return;
                            }
                        }


                    }

                    else
                    {

                        MessageBox.Show("Not connected to the database!");
                        return;
                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
                return;
            }
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            Room dn = new Room();
            dn.Show();
        }

        private void btn_modify_Click_1(object sender, EventArgs e)
        {
            if (dgvCus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to modify.");
                return;
            }

            // Lấy MA_NGUOITHUE từ dòng được chọn (quan trọng)
            int maNguoiThue = Convert.ToInt32(dgvCus.SelectedRows[0].Cells["MA_NGUOITHUE"].Value);


            string selectedUsername = dgvCus.SelectedRows[0].Cells["HOTEN_NT"].Value.ToString();
            string selectedSDT = dgvCus.SelectedRows[0].Cells["SDT"].Value.ToString();
            string selectedEmail = dgvCus.SelectedRows[0].Cells["EMAIL"].Value.ToString();

            using (Add_Customers modify_KHForm = new Add_Customers())
            {
                modify_KHForm.IsModify = true; // Đặt cờ IsModify
                modify_KHForm.MaNguoiThue = maNguoiThue; // Truyền MA_NGUOITHUE
                modify_KHForm.SelectedHOTEN_NT = selectedUsername;
                modify_KHForm.SelectedSDT = selectedSDT;
                modify_KHForm.SelectedEMAIL = selectedEmail;
                

                if (modify_KHForm.ShowDialog() == DialogResult.OK)
                {
                    LoadKhachHang();
                }
            }
        }
    }
}

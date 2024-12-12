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
    public partial class Add_Customers : Form
    {
        public bool IsModify { get; set; } // Cờ để phân biệt Add và Modify
        public int MaNguoiThue { get; set; } // Biến để lưu trữ MA_NGUOITHUE
        public string SelectedHOTEN_NT { get; set; }
        public string SelectedSDT { get; set; }
        public string SelectedEMAIL { get; set; }

    
        public Add_Customers()
        {
            InitializeComponent();
            CenterToScreen();
 
        }

        private void Add_Customers_Load(object sender, EventArgs e)
        {
            if (IsModify) // Nếu là chế độ Modify
            {
                txtName.Text = SelectedHOTEN_NT;
                txtSDT.Text = SelectedSDT;
                txtEmail.Text = SelectedEMAIL;

                btnAdd.Text = "SUBMIT MODIFY"; // Đổi text của button
            }
            else // Nếu là chế độ Add
            {
                btnAdd.Text = "SUBMIT ADD";

            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsModify)
            {
                ModifyCustomer();
            }
            else
            {
                AddCustomer();
            }
        }
        private void AddCustomer()
        {
            try
            {
                string name = txtName.Text;
                string sdt = txtSDT.Text;
                string email = txtEmail.Text;
                string idRoom = txtRoom.Text;
                string checkIn = dtCheckin.Value.ToString("dd-MMM-yyyy");
                string checkOut = dtCheckout.Value.ToString("dd-MMM-yyyy");
                int maNguoiThue = GenerateRandomID();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập tên và số điện thoại.");
                    return;
                }


                if (!string.IsNullOrEmpty(idRoom))
                {

                    try
                    {
                        int idRoomInt = int.Parse(idRoom);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("ID ROOM không hợp lệ");
                        return;

                    }

                }

                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        using (OracleCommand cmdInsertNguoiThue = new OracleCommand("INSERT INTO BMCSDL_1.NGUOITHUE (MA_NGUOITHUE, HOTEN_NT, SDT, EMAIL) VALUES (:maNguoiThue, :hoten, :sdt, :email)", connection))
                        {
                            cmdInsertNguoiThue.Parameters.Add(":maNguoiThue", maNguoiThue);
                            cmdInsertNguoiThue.Parameters.Add(":hoten", name);
                            cmdInsertNguoiThue.Parameters.Add(":sdt", sdt);
                            cmdInsertNguoiThue.Parameters.Add(":email", email);
                            cmdInsertNguoiThue.ExecuteNonQuery();
                        }


                        // Thêm vào bảng DAT_PHONG (nếu có ID Room và Check-in/Check-out)


                        if (!string.IsNullOrEmpty(idRoom) && !string.IsNullOrEmpty(checkIn) && !string.IsNullOrEmpty(checkOut))
                        {
                            int maDatPhong = GenerateRandomID();





                            using (OracleCommand cmdInsertDatPhong = new OracleCommand("INSERT INTO BMCSDL_1.DAT_PHONG (MA_DATPHONG, MA_PHONG, MA_NGUOITHUE, NGAY_VAO, NGAY_RA) VALUES (:maDatPhong, :idRoom, :maNguoiThue, TO_DATE(:checkIn, 'dd-mon-yyyy'), TO_DATE(:checkOut, 'dd-mon-yyyy'))", connection))
                            {


                                cmdInsertDatPhong.Parameters.Add(":maDatPhong", maDatPhong);
                                cmdInsertDatPhong.Parameters.Add(":idRoom", idRoom);
                                cmdInsertDatPhong.Parameters.Add(":maNguoiThue", maNguoiThue);
                                cmdInsertDatPhong.Parameters.Add(":checkIn", checkIn);
                                cmdInsertDatPhong.Parameters.Add(":checkOut", checkOut);
                                cmdInsertDatPhong.ExecuteNonQuery();

                            }

                        }
                        MessageBox.Show("Thêm khách hàng thành công!");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void ModifyCustomer()
        {
            try
            {
                string name = txtName.Text;
                string sdt = txtSDT.Text;
                string email = txtEmail.Text;
                string idRoom = txtRoom.Text;

                string checkIn = dtCheckin.Value.ToString("dd-MMM-yyyy");
                string checkOut = dtCheckout.Value.ToString("dd-MMM-yyyy");

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập tên và số điện thoại.");
                    return;
                }

                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        using (OracleTransaction transaction = connection.BeginTransaction()) // Sử dụng transaction
                        {
                            try
                            {
                                // Cập nhật bảng NGUOITHUE
                                using (OracleCommand cmdUpdateNguoiThue = new OracleCommand("UPDATE BMCSDL_1.NGUOITHUE SET HOTEN_NT = :hoten, SDT = :sdt, EMAIL = :email WHERE MA_NGUOITHUE = :maNguoiThue", connection))
                                {
                                    cmdUpdateNguoiThue.Transaction = transaction; // Thêm transaction
                                    cmdUpdateNguoiThue.Parameters.Add(":hoten", name);
                                    cmdUpdateNguoiThue.Parameters.Add(":sdt", sdt);
                                    cmdUpdateNguoiThue.Parameters.Add(":email", email);
                                    cmdUpdateNguoiThue.Parameters.Add(":maNguoiThue", MaNguoiThue); // Sử dụng MaNguoiThue được truyền vào
                                    cmdUpdateNguoiThue.ExecuteNonQuery();
                                }

                                // Cập nhật bảng DAT_PHONG (nếu có ID Room và Check-in/Check-out)
                                if (!string.IsNullOrEmpty(idRoom) && !string.IsNullOrEmpty(checkIn) && !string.IsNullOrEmpty(checkOut))
                                {
                                    using (OracleCommand cmdUpdateDatPhong = new OracleCommand(@"UPDATE BMCSDL_1.DAT_PHONG 
                                                                                    SET MA_PHONG = :idRoom, 
                                                                                        NGAY_VAO = TO_DATE(:checkIn, 'dd-mon-yyyy'), 
                                                                                        NGAY_RA = TO_DATE(:checkOut, 'dd-mon-yyyy') 
                                                                                    WHERE MA_NGUOITHUE = :maNguoiThue", connection))

                                    {
                                        cmdUpdateDatPhong.Transaction = transaction;
                                        cmdUpdateDatPhong.Parameters.Add(":idRoom", idRoom);
                                        cmdUpdateDatPhong.Parameters.Add(":checkIn", checkIn);
                                        cmdUpdateDatPhong.Parameters.Add(":checkOut", checkOut);
                                        cmdUpdateDatPhong.Parameters.Add(":maNguoiThue", MaNguoiThue);


                                        int rowsAffected = cmdUpdateDatPhong.ExecuteNonQuery();

                                        if (rowsAffected == 0)
                                        {
                                            MessageBox.Show("Không tìm thấy khách hàng trong bảng DAT_PHONG.");


                                        }
                                    }
                                }
                                transaction.Commit(); // Commit transaction
                                MessageBox.Show("Sửa khách hàng thành công!");
                                this.DialogResult = DialogResult.OK;
                                this.Close();
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
                        MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu.");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GenerateRandomID()
        {
            Random random = new Random();
            return random.Next(100000, 999999); 
        }


    }
}

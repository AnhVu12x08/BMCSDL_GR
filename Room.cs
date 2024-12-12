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
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
            LoadPhong();
        }
        private void LoadPhong()
        {
            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        using (OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM BMCSDL_1.PHONG", connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvRoom.DataSource = dt; 
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
                MessageBox.Show($"Error loading phòng: {ex.Message}");
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete.");
                return;
            }

            try
            {
                using (OracleConnection connection = Database.Get_Connect())
                {
                    if (connection != null)
                    {
                        int maPhong = Convert.ToInt32(dgvRoom.SelectedRows[0].Cells["MA_PHONG"].Value);

                        using (OracleCommand cmd = new OracleCommand("DELETE FROM BMCSDL_1.PHONG WHERE MA_PHONG = :maPhong", connection))
                        {
                            cmd.Parameters.Add(":maPhong", maPhong);
                            cmd.ExecuteNonQuery();
                            LoadPhong(); // Refresh DataGridView sau khi xóa
                            MessageBox.Show("Phòng deleted successfully.");
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
                MessageBox.Show($"Error deleting phòng: {ex.Message}");
            }
        }


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            QLKH dn = new QLKH();
            dn.Show();
        }
    }
}

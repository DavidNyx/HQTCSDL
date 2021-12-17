using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HQT_Project
{
    public partial class capnhatdonhang_taixe : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        SqlCommand cmd;
        public capnhatdonhang_taixe()
        {
            InitializeComponent();
            comboBox1.Items.Add("Đang giao hàng");
            comboBox1.Items.Add("Hoàn tất");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox1.Text != "" || comboBox1.SelectedItem != null || textBox2.Text != "")
                {//check ma don hang nhap vo
                    sqlConn.Open();
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * from donhang where qtvc NOT LIKE N'Hoàn tất' and cmnd = '" + textBox2.Text + "' and madh = '" + textBox1.Text + "' ", sqlConn);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Đơn hàng không hợp lệ hoặc đã hoàn tất!");
                    }
                    else
                    {
                        //take value from combo box
                        object selecteditem = comboBox1.SelectedItem;
                        string value = selecteditem.ToString();
                        //check tinh trang la dang giao hang
                        SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT * FROM donhang WHERE qtvc = N'Đang giao hàng' and madh = '" + textBox1.Text + "' and cmnd = '" + textBox2.Text + "' ", sqlConn);
                        DataTable table2 = new DataTable();
                        adapt2.Fill(table2);
                        //check tinh trang la dang giao hang
                        SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * FROM donhang WHERE qtvc = N'Đã hoàn tất' and madh = '" + textBox1.Text + "' and cmnd = '" + textBox2.Text + "' ", sqlConn);
                        DataTable table3 = new DataTable();
                        adapt3.Fill(table3);
                        if (table3.Rows.Count >= 1 && value != "Đã hoàn tất")
                        {
                            MessageBox.Show("Đơn hàng đã hoàn tất!");
                        }
                        else
                        {
                            string madh = textBox1.Text;
                            cmd = new SqlCommand("EXEC dbo.UPDATE_DONHANG '" + madh + "', N'" + value + "'" , sqlConn);
                            cmd.ExecuteNonQuery();
                            sqlConn.Close();
                            MessageBox.Show("Cập nhật đơn hàng thành công");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox2.Text != "")
                {
                    sqlConn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from taixe where cmnd = '" + textBox2.Text + "' ", sqlConn);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    if (table.Rows.Count < 1)
                    {
                        MessageBox.Show("Tài xế không tồn tại!");
                    }
                    else
                    {
                        SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * FROM donhang WHERE qtvc NOT LIKE N'Hoàn tất' and cmnd = '" + textBox2.Text + "' ", sqlConn);
                        DataTable table1 = new DataTable();
                        adapt1.Fill(table1);
                        dataGridView1.DataSource = new BindingSource(table1, null);
                        sqlConn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin tài xế để xem danh sách đơn hàng!");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

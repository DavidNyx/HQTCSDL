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
    public partial class xemdonhang_khachhang : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public xemdonhang_khachhang()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void xemdonhang_khachhang_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // danh sach don hang
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox1.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT makh from khachhang where khachhang.makh = '" + textBox1.Text + "' ", sqlConn);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã khách hàng không tồn tại!");
                    }
                    else
                    {
                        //show tat ca don hang
                        sqlConn.Open();
                        //data 1
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from donhang where donhang.makh = '" + textBox1.Text + "'", sqlConn);
                        DataTable table = new DataTable();
                        adapt.Fill(table);
                        dataGridView1.DataSource = new BindingSource(table, null);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin!");
                }
                
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox2.Text != "")
                {
                    SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT * from donhang where donhang.makh = '" + textBox1.Text + "' and donhang.madh = '" + textBox2.Text + "' ", sqlConn);
                    DataTable table2 = new DataTable();
                    adapt2.Fill(table2);
                    if (table2.Rows.Count < 1)
                    {
                        MessageBox.Show("Đơn hàng không thuộc khách hàng!");
                    }
                    else
                    {
                        sqlConn.Open();
                        //data 1
                        SqlDataAdapter adapt = new SqlDataAdapter("exec dbo.FOLLOW_DONHANG_KH '" + textBox1.Text + "', '"+textBox2.Text+"' ", sqlConn);
                        DataTable table = new DataTable();
                        adapt.Fill(table);
                        dataGridView2.DataSource = new BindingSource(table, null);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin!");
                }
            }
        }
    }
}

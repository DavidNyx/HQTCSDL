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
    public partial class themsp : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public themsp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from sanpham", sqlConn);
                DataTable table = new DataTable();
                adapt.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
                sqlConn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "")
                {
                    //CHECK
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT SANPHAM.MASP from sanpham where MASP = '" + textBox1.Text + "' ", sqlConn);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    if (table.Rows.Count >= 1)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại!");
                    }
                    else
                    {
                        //ma doi tac 
                        SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT loaisp.maloai from loaisp where maLOAI = '" + textBox2.Text + "' ", sqlConn);
                        DataTable table1 = new DataTable();
                        adapt1.Fill(table1);
                        if (table1.Rows.Count < 1)
                        {
                            MessageBox.Show("Loại sản phẩm không tồn tại!");
                        }
                        else
                        {
                            cmd = new SqlCommand("insert into sanpham(masp,maloai,tenSP,mota,gia) values(@masp,@maloai,@ten,@mota,@gia)", sqlConn);
                            sqlConn.Open();
                            cmd.Parameters.AddWithValue("@masp", textBox1.Text);
                            cmd.Parameters.AddWithValue("@maloai", textBox2.Text);
                            cmd.Parameters.AddWithValue("@ten", textBox3.Text);
                            cmd.Parameters.AddWithValue("@mota", textBox4.Text);
                            cmd.Parameters.AddWithValue("@gia", textBox5.Text);
                            cmd.ExecuteNonQuery();
                            sqlConn.Close();
                            MessageBox.Show("Thêm thành công");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin!");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

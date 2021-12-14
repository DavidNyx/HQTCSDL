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
    public partial class muahang_taohd : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        private string madh = "DH";
        public muahang_taohd()
        {
            InitializeComponent();
        }

        private void muahang_taohd_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Tiền mặt");
            comboBox1.Items.Add("Thẻ");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //makh
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //madoitac
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
               if (textBox2.Text != "")
                {
                    sqlConn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT distinct sanpham.masp, sanpham.tensp, sanpham.maloai, sanpham.mota, sanpham.gia, quanlykho.slsp from sanpham, quanlykho where quanlykho.masp = sanpham.masp and quanlykho.madoitac = '" + textBox2.Text + "' ", sqlConn);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    dataGridView1.DataSource = new BindingSource(table, null);
                    sqlConn.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã đối tác để xem các sản phẩm của đối tác đó!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hoan thanh tao
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();

                //check
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT donhang.madh from donhang where madh = '" + textBox1.Text + "' ", sqlConn);
                DataTable table = new DataTable();
                adapt.Fill(table);
                if (table.Rows.Count >= 1)
                {
                    MessageBox.Show("Mã đơn hàng đã tồn tại!");
                }
                else
                {
                    //ma doi tac 
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT DOITAC.madoitac from DOITAC where madoitac = '" + textBox2.Text + "' ", sqlConn);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã đối tác không tồn tại!");
                    }
                    else
                    {
                        //ma khach hang
                        SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT KHACHHANG.makh from KHACHHANG where makh = '" + textBox3.Text + "' ", sqlConn);
                        DataTable table2 = new DataTable();
                        adapt2.Fill(table2);
                        if (table2.Rows.Count < 1)
                        {
                            MessageBox.Show("Mã khách hàng không tồn tại!");
                        }
                        else
                        {
                            //ma don hang
                            SqlCommand cmd = new SqlCommand("insert into DONHANG (madh) values ('" + textBox1.Text + "' )", sqlConn);
                           
                            //ma doi tac
                            SqlCommand cmd1 = new SqlCommand("insert into DONHANG (madoitac) values ('" + textBox2.Text + "' )", sqlConn);
                            
                            //ma khach hang
                            SqlCommand cmd2 = new SqlCommand("insert into DONHANG (madoitac) values ('" + textBox3.Text + "' )", sqlConn);
                            
                            //Hinh thuc thanh toan
                            SqlCommand cmd3 = new SqlCommand("insert into DONHANG (htthanhtoan) values ('" + comboBox1.SelectedItem + "' )", sqlConn);
                            
                            cmd.ExecuteNonQuery();
                            cmd1.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            cmd3.ExecuteNonQuery();
                        }
                    }
                }
                    //
                sqlConn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from doitac", sqlConn);
                DataTable table = new DataTable();
                adapt.Fill(table);
                dataGridView2.DataSource = new BindingSource(table, null);
                sqlConn.Close();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //masp
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            //slmua
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ghi nhan
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //tao don hang
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT DOITAC.madoitac from DOITAC where madoitac = '" + textBox2.Text + "' ", sqlConn);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã đối tác không tồn tại!");
                    }
                    else
                    {
                        SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT khachhang.makh from khachhang where khachhang.makh = '" + textBox3.Text + "' ", sqlConn);
                        DataTable table2 = new DataTable();
                        adapt2.Fill(table2);
                        if (table2.Rows.Count < 1)
                        {
                            MessageBox.Show("Mã khách hàng không tồn tại!");
                        }
                        else
                        {
                            //tao ma don hang random
                            int length = 10;
                            while (true)
                            {
                                Random random = new Random();

                                for (int i = 0; i < length; i++)
                                {
                                    int flt = random.Next(10);
                                    madh = madh + flt.ToString();
                                }
                                SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT donhang.madh from donhang where donhang.madh = '" + madh + "' ", sqlConn);
                                DataTable table3 = new DataTable();
                                adapt3.Fill(table3);
                                if (table3.Rows.Count < 1)
                                {
                                    label8.Text = madh;
                                    break;
                                }
                                //check ma don hang  
                            }
                        }    
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

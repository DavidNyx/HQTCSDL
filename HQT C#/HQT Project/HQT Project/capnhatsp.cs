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
    public partial class capnhatsp : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public capnhatsp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox6.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT madoitac from doitac where doitac.madoitac = '" + textBox6.Text + "' ", sqlConn);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã đối tác không tồn tại!");
                    }
                    else
                    {
                        sqlConn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT DISTINCT quanlykho.masp, quanlykho.macn, sanpham.tensp, sanpham.maloai, sanpham.mota, sanpham.gia from sanpham, quanlykho where QUANLYKHO.MASP = SANPHAM.MASP AND quanlykho.madoitac = '" + textBox6.Text + "'", sqlConn);
                        DataTable table = new DataTable();
                        adapt.Fill(table);
                        dataGridView1.DataSource = new BindingSource(table, null);
                        sqlConn.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã đối tác để được coi danh sách sản phẩm!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "")
                {
                    //CHECK
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from QUANLYKHO where QUANLYKHO.MASP = '" + textBox1.Text + "' AND QUANLYKHO.MADOITAC = '" + textBox6.Text + "' ", sqlConn);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    if (table.Rows.Count < 1)
                    {
                        MessageBox.Show("Sản phẩm không thuộc đối tác này!");
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
                            string masp = textBox1.Text, maloai = textBox2.Text, tensp = textBox3.Text, mota = textBox4.Text;
                            float gia = float.Parse(textBox5.Text);
                            sqlConn.Open();
                            cmd = new SqlCommand("EXEC dbo.CAPNHATSP '" + masp + "','" + maloai + "', N'" + tensp + "', N'" + mota + "','" + gia + "'", sqlConn);
                            cmd.ExecuteNonQuery();
                            sqlConn.Close();
                            MessageBox.Show("Cập nhật thành công");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin!");
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void capnhatsp_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            menudoitac capnhat = new menudoitac();
            capnhat.ShowDialog();
            this.Close();
        }
    }
}

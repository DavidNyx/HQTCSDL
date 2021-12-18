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
    public partial class capnhatsl : Form
    {
        //string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        SqlCommand cmd;
        //SqlDataAdapter adapt;
        public capnhatsl()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox3.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT madoitac from doitac where doitac.madoitac = '" + textBox3.Text + "' ", nachos.sqlCon);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã đối tác không tồn tại!");
                    }
                    else
                    {
                        nachos.sqlCon.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT DISTINCT sanpham.masp, quanlykho.macn, sanpham.tensp, sanpham.maloai, quanlykho.slsp , sanpham.mota, sanpham.gia from sanpham, quanlykho where quanlykho.masp = sanpham.masp AND quanlykho.madoitac = '" + textBox3.Text + "'", nachos.sqlCon);
                        DataTable table = new DataTable();
                        adapt.Fill(table);
                        dataGridView1.DataSource = new BindingSource(table, null);
                        nachos.sqlCon.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã đối tác để được coi danh sách sản phẩm!");
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    //CHECK
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from QUANLYKHO where QUANLYKHO.MASP = '" + textBox1.Text + "' AND QUANLYKHO.MADOITAC = '" + textBox3.Text + "' AND QUANLYKHO.MACN = '" +textBox2.Text+ "' ", nachos.sqlCon);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    if (table.Rows.Count < 1)
                    {
                        MessageBox.Show("Sản phẩm không thuộc kho của đối tác này!");
                    }
                    else
                    {
                        string masp = textBox1.Text, macn = textBox2.Text, madt = textBox3.Text;
                        int sl = int.Parse(textBox4.Text);
                        if(sl < 0)
                        {
                            MessageBox.Show("Số lượng tăng thêm phải lớn hơn 0!");
                        }
                        else
                        {
                            nachos.sqlCon.Open();
                            cmd = new SqlCommand("EXEC dbo.UPDATE_SOLUONG '" + madt + "','" + macn + "','" + masp + "','" + sl + "'", nachos.sqlCon);
                            cmd.ExecuteNonQuery();
                            nachos.sqlCon.Close();
                            MessageBox.Show("Cập nhật thành công");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin!");
                }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //sl
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //masp
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //macn
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

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

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT donhang.madh, donhang.madoitac , donhang.makh, donhang.htthanhtoan from donhang", sqlConn);
                DataTable table = new DataTable();
                adapt.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
                sqlConn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}

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
    public partial class capnhatdonhang_doitac : Form
    {
        //string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        SqlCommand cmd;
        public capnhatdonhang_doitac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox1.Text != "")
                {
                    nachos.sqlCon.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from donhang where donhang.QTVC is NULL and donhang.madh = '"+ textBox1.Text +"' ", nachos.sqlCon);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    if(table.Rows.Count < 1)
                    {
                        MessageBox.Show("Đơn hàng cần xác nhận không hợp lệ!");
                    }
                    else
                    {
                        cmd = new SqlCommand("update donhang set donhang.QTVC = N'Đã xác nhận' where donhang.madh = '" + textBox1.Text + "' " , nachos.sqlCon);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xác nhận đơn hàng thành công");
                    }    
                    nachos.sqlCon.Close();
                }    
                else
                {
                    MessageBox.Show("Vui lòng nhập mã đơn hàng cần xác nhận!");
                }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void capnhatdonhang_doitac_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            nachos.sqlCon.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT donhang.madh, donhang.makh, donhang.htthanhtoan from donhang where donhang.QTVC is NULL", nachos.sqlCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
                nachos.sqlCon.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            menudoitac them = new menudoitac();
            them.ShowDialog();
            this.Close();
        }
    }
}

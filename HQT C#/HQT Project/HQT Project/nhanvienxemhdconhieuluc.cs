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
    public partial class nhanvienxemhdconhieuluc : Form
    {
        //string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        //SqlCommand cmd;
        public nhanvienxemhdconhieuluc()
        {
            InitializeComponent();
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            nachos.sqlCon.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT doitac.madoitac, doitac.tendoitac from doitac", nachos.sqlCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
                nachos.sqlCon.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox1.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT madoitac from doitac where doitac.madoitac = '" + textBox1.Text + "' ", nachos.sqlCon);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã đối tác không tồn tại!");
                    }
                    else
                    {
                        nachos.sqlCon.Open();
                        string cmnd = textBox1.Text;
                        SqlDataAdapter adapt2 = new SqlDataAdapter("exec XEMHD '" + cmnd + "'", nachos.sqlCon);
                        DataTable table2 = new DataTable();
                        adapt2.Fill(table2);
                        dataGridView2.DataSource = new BindingSource(table2, null);
                        nachos.sqlCon.Close();
                    }
                }   
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin mã đối tác để xem hợp đồng!");
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox2.Text != "" || textBox3.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * FROM dbo.HOPDONG WHERE MADOITAC = '"+ textBox2.Text +"' AND TGHIEULUC > GETDATE() and mathue = '"+ textBox3.Text +"' ", nachos.sqlCon);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Hợp đồng còn hiệu lực của đối tác không tồn tại!");
                    }
                    else
                    {
                        //label6.Text = maskedTextBox1.Text;
                        SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT TGHIEULUC FROM dbo.HOPDONG WHERE madoitac = '" + textBox2.Text + "' AND MATHUE = '" + textBox3.Text + "' AND TGHIEULUC > '" + maskedTextBox1.Text + "' ", nachos.sqlCon);
                        DataTable table2 = new DataTable();
                        adapt2.Fill(table2);
                        if (table2.Rows.Count >= 1)
                        {
                            MessageBox.Show("Ngày gia hạn không hợp lệ!");
                        }
                        else
                        {
                            MessageBox.Show("Thông báo gia hạn hợp đồng đến " + maskedTextBox1.Text + " được gửi đến hợp đồng của đối tác " +textBox2.Text + " có mã thuế "+textBox3.Text+" thành công");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin hợp đồng và ngày gia hạn!");
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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            menunhanvien them = new menunhanvien();
            them.ShowDialog();
            this.Close();
        }
    }
}

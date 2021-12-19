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
    public partial class nhanvienupdatehopdong : Form
    {
        SqlCommand cmd;
        public nhanvienupdatehopdong()
        {
            InitializeComponent();
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT*FROM dbo.HOPDONG", nachos.sqlCon);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            dataGridView1.DataSource = new BindingSource(table1, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox4.Text != "" && textBox2.Text !="" && maskedTextBox1.Text !="" && textBox1.Text != "")
            {
                nachos.sqlCon.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM hopdong where madoitac = '" + textBox1.Text + "' and mathue = '" + textBox2.Text + "' ", nachos.sqlCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                if(table.Rows.Count < 1)
                {
                    MessageBox.Show("Hợp đồng không tồn tại!");
                }
                else
                {
                    //check ngay gia han
                    SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT TGHIEULUC FROM dbo.HOPDONG WHERE madoitac = '" + textBox1.Text + "' AND MATHUE = '" + textBox2.Text + "' AND TGHIEULUC > '" + maskedTextBox1.Text + "' ", nachos.sqlCon);
                    DataTable table2 = new DataTable();
                    adapt2.Fill(table2);
                    if (table2.Rows.Count >= 1)
                    {
                        MessageBox.Show("Ngày gia hạn không hợp lệ!");
                    }
                    else
                    {
                        string madt = textBox1.Text, mathue = textBox2.Text;
                        float phantram = float.Parse(textBox4.Text);
                        cmd = new SqlCommand("EXEC dbo.UPDATE_HOPDONG '" + madt + "','" + mathue + "','" + maskedTextBox1.Text + "', '"+ phantram +"' ", nachos.sqlCon);
                        cmd.ExecuteNonQuery();
                        nachos.sqlCon.Close();
                        MessageBox.Show("Cập nhật hợp đồng thành công!");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            menunhanvien them = new menunhanvien();
            them.ShowDialog();
            this.Close();
        }
    }
}

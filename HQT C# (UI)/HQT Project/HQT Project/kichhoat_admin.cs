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
    public partial class kichhoat_admin : Form
    {
        SqlCommand cmd;
        public kichhoat_admin()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox1.Text != "" && comboBox1.SelectedItem != null && textBox3.Text != "")
            {
                nachos.sqlCon.Open();
                SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * FROM TAIKHOAN WHERE USERNAME = '" + textBox1.Text + "' and pass = '"+textBox3.Text+"' ", nachos.sqlCon);
                DataTable table1 = new DataTable();
                adapt1.Fill(table1);
                if (table1.Rows.Count < 1)
                {
                    MessageBox.Show("Tài khoản không hợp lệ!");
                }
                else
                {
                    object selecteditem = comboBox1.SelectedItem;
                    string value = selecteditem.ToString();
                    cmd = new SqlCommand("sp_addlogin '" + textBox1.Text + "', '"+textBox3.Text+"' ", nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("create user " + textBox1.Text + " for login " + textBox1.Text + " ", nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("sp_addrolemember '" + value + "', '" + textBox1.Text + "' ", nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update taikhoan set taikhoan.user_status = 1 where username = '" + textBox1.Text + "' ", nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kích hoạt tài khoản thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            nachos.sqlCon.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT username, pass, user_role FROM TAIKHOAN WHERE user_status = 0 ", nachos.sqlCon);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView1.DataSource = new BindingSource(table, null);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuadmin them = new menuadmin();
            them.ShowDialog();
            this.Close();
        }
    }
}

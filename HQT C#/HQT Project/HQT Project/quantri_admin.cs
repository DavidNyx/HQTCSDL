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
    public partial class quantri_admin : Form
    {
        SqlCommand cmd;

        public quantri_admin()
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
                //check username
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT USERNAME FROM TAIKHOAN WHERE USERNAME = '" + textBox1.Text + "' ", nachos.sqlCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                if (table.Rows.Count < 1)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                }
                else
                {
                    cmd = new SqlCommand("drop login " + textBox1.Text, nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("drop user " + textBox1.Text, nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("delete taikhoan where username = '" + textBox1.Text + "' ", nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    nachos.sqlCon.Close();
                    MessageBox.Show("Xóa tài khoản thành công");
                }
                nachos.sqlCon.Close();
            }
            //
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

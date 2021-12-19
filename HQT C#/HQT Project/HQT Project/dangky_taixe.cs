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
using System.IO;

namespace HQT_Project
{
    public partial class dangky_taixe : Form
    {
        SqlCommand cmd;
        public dangky_taixe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            //tim file
            var path = Path.Combine(Directory.GetCurrentDirectory(), "config.txt");
            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (count == 0)
                {
                    nachos.servername = line;
                }
                else if (count == 1)
                {
                    nachos.dbname = line;
                }
                count++;
            }
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=guest password=guest";
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                nachos.sqlCon.Open();
                //check username
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT USERNAME FROM TAIKHOAN WHERE USERNAME = '" + textBox2.Text + "' ", nachos.sqlCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                if (table.Rows.Count >= 1)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!");
                }
                else
                {
                    cmd = new SqlCommand("insert taikhoan(USERNAME, PASS, USER_ROLE) values ('" + textBox2.Text + "','" + textBox1.Text + "', N'" + label5.Text + "' )", nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert taixe(CMND, HOTEN, SDTTAIXE, DIACHITX, BIENSO, KHUVUCHD, EMAILTAIXE, TKNGH, SODONHANG, THUNHAP, USERNAME) values ('" + textBox3.Text + "', N'" + textBox9.Text + "', '" + textBox7.Text + "' , N'" + textBox10.Text + "' , '" + textBox4.Text + "' , N'" + textBox5.Text + "','" + textBox6.Text + "' , '" + textBox8.Text + "', NULL, NULL, '" + textBox2.Text + "' )", nachos.sqlCon);
                    cmd.ExecuteNonQuery();
                    nachos.sqlCon.Close();
                    MessageBox.Show("Tạo tài khoản thành công");
                    this.Hide();
                    login them = new login();
                    them.ShowDialog();
                    this.Close();
                }
                nachos.sqlCon.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

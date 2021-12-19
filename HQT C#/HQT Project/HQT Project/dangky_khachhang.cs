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
    public partial class dangky_khachhang : Form
    {
        SqlCommand cmd;
        private string makh = "KH";
        public dangky_khachhang()
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox6.Text != "" && textBox7.Text !="" && textBox9.Text != "" && textBox10.Text != "")
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
                    
                    //tao makh
                    int length = 10;
                    while (true)
                    {
                        Random random = new Random();

                        for (int i = 0; i < length; i++)
                        {
                            int flt = random.Next(10);
                            makh = makh + flt.ToString();
                        }
                        SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT makh from khachhang where makh = '" + makh + "' ", nachos.sqlCon);
                        DataTable table3 = new DataTable();
                        adapt3.Fill(table3);
                        if (table3.Rows.Count < 1) // neu ma don hang chua ton tai
                        {
                            label14.Text = makh;
                            cmd = new SqlCommand("insert taikhoan(USERNAME, PASS, USER_ROLE) values ('" + textBox2.Text + "','" + textBox1.Text + "', N'" + label5.Text + "' )", nachos.sqlCon);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("insert khachhang(MAKH, HOTENKH, SDTKH, DIACHIKH, EMAILKH, USERNAME) values ('" + makh + "', N'" + textBox9.Text + "', '" + textBox7.Text + "' , N'" + textBox10.Text + "' , '" + textBox6.Text + "' , '" + textBox2.Text + "' )", nachos.sqlCon);
                            cmd.ExecuteNonQuery();
                            nachos.sqlCon.Close();
                            MessageBox.Show("Tạo tài khoản thành công");
                            this.Hide();
                            login buy = new login();
                            buy.ShowDialog();
                            this.Close();
                            break;
                        }
                    }
                    //
                    
                }
                nachos.sqlCon.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

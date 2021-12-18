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
    //tao server name va cqq j do'

    //string[] lines = File.ReadAllLines(path);
    //string connString = @"Data Source="+lines[0]+";Initial Catalog="+lines[1]+";Integrated Security=True"


    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
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
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text !="")
            {
                string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + textBox2.Text.Trim() + "password=" + textBox1.Text.Trim(); ;
                nachos.sqlCon = new SqlConnection(connString);
                //sqlCon = nachos.sqlCon;
                //phan trang
                //
                SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * FROM taikhoan WHERE username= '" + textBox2.Text + "' and pass='" + textBox1.Text + "' ", nachos.sqlCon);
                DataTable table1 = new DataTable();
                adapt1.Fill(table1);
                if (table1.Rows.Count >= 1) // dang nhap thanh cong
                {
                    nachos.username = textBox2.Text;
                    nachos.password = textBox1.Text;
                    this.Hide();
                    quantri_admin them = new quantri_admin();
                    them.ShowDialog();
                    this.Close(); 
                }
                //
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.PasswordChar = '●';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //sqlCon = nachos.sqlCon;
            //phan trang
            this.Hide();
            vaitro them = new vaitro();
            them.ShowDialog();
            this.Close();
        }
    }

    public static class nachos
    {
        public static SqlConnection sqlCon = null;
        public static string username = "";
        public static string servername = "";
        public static string dbname = "";
        public static string password = "";
    }

}

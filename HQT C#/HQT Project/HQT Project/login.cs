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
                    //xet role de phan trang
                    //nhan vien
                    SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT * FROM taikhoan WHERE user_role = N'Nhân viên' and username= '" + textBox2.Text + "' and pass='" + textBox1.Text + "' ", nachos.sqlCon);
                    DataTable table2 = new DataTable();
                    adapt2.Fill(table2);
                    if (table2.Rows.Count >= 1) // neu la nhan vien 
                    {
                        this.Hide();
                        menunhanvien them = new menunhanvien();
                        them.ShowDialog();
                        this.Close();
                    }
                    //tai xe
                    SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * FROM taikhoan WHERE user_role = N'Tài xế' and username= '" + textBox2.Text + "' and pass='" + textBox1.Text + "' ", nachos.sqlCon);
                    DataTable table3 = new DataTable();
                    adapt3.Fill(table3);
                    if (table3.Rows.Count >= 1) // neu la nhan vien 
                    {
                        this.Hide();
                        menutaixe them = new menutaixe();
                        them.ShowDialog();
                        this.Close();
                    }
                    //doitac
                    SqlDataAdapter adapt4 = new SqlDataAdapter("SELECT * FROM taikhoan WHERE user_role = N'Đối tác' and username= '" + textBox2.Text + "' and pass='" + textBox1.Text + "' ", nachos.sqlCon);
                    DataTable table4 = new DataTable();
                    adapt4.Fill(table4);
                    if (table4.Rows.Count >= 1) // neu la nhan vien 
                    {
                        this.Hide();
                        menudoitac them = new menudoitac();
                        them.ShowDialog();
                        this.Close();
                    }
                    //khach hang
                    SqlDataAdapter adapt5 = new SqlDataAdapter("SELECT * FROM taikhoan WHERE user_role = N'Khách hàng' and username= '" + textBox2.Text + "' and pass='" + textBox1.Text + "' ", nachos.sqlCon);
                    DataTable table5 = new DataTable();
                    adapt5.Fill(table5);
                    if (table5.Rows.Count >= 1) // neu la nhan vien 
                    {
                        this.Hide();
                        menudoitac them = new menudoitac();
                        them.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                        menuadmin them = new menuadmin();
                        them.ShowDialog();
                        this.Close();
                    }
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

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
    public partial class doitactaohopdong : Form
    {
        SqlCommand cmd;
        public doitactaohopdong()
        {
            InitializeComponent();
            
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //test
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            //
            if (textBox1.Text !="" && textBox2.Text !="" && textBox5.Text != "")
            {
                //check ma doi tac
                nachos.sqlCon.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT * from doitac where madoitac = '" + textBox1.Text + "' ", nachos.sqlCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                if (table.Rows.Count < 1)
                {
                    MessageBox.Show("Đối tác không tồn tại!");
                }
                else
                {
                    //check hop dong
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * from hopdong where madoitac = '" + textBox1.Text + "' and mathue = '" + textBox2.Text + "' ", nachos.sqlCon);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count >= 1)
                    {
                        MessageBox.Show("Hợp đồng đã tồn tại!");
                    }
                    else
                    {
                        //XET thoi gian
                        string madt = textBox1.Text, mathue = textBox2.Text;
                        int socn = int.Parse(textBox5.Text);
                        cmd = new SqlCommand("EXEC dbo.LAP_HOP_DONG '" + madt + "','" + mathue + "','" + socn + "', '" + maskedTextBox1.Text + "' ", nachos.sqlCon);
                        cmd.ExecuteNonQuery();
                        nachos.sqlCon.Close();
                        MessageBox.Show("Lập hợp đồng thành công!");
                    }
                }
                //
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menudoitac them = new menudoitac();
            them.ShowDialog();
            this.Close();
        }
    }
}

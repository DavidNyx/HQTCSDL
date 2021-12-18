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
    public partial class xemdonhang_taixe : Form
    {
        
        public xemdonhang_taixe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            if (textBox1.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT cmnd from taixe where taixe.cmnd = '" + textBox1.Text + "' ", nachos.sqlCon);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Tài xế không tồn tại!");
                    }
                    else
                    {
                        nachos.sqlCon.Open();
                        //data 1
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT donhang.madh, donhang.madoitac, donhang.makh, donhang.slsp, donhang.phisp, donhang.qtvc from taixe, donhang where taixe.cmnd = '" + textBox1.Text + "'", nachos.sqlCon);
                        DataTable table = new DataTable();
                        adapt.Fill(table);
                        dataGridView1.DataSource = new BindingSource(table, null);
                        //data 2
                        SqlDataAdapter adapt2 = new SqlDataAdapter("exec FOLLOW_DONHANG_TX '" + textBox1.Text + "'", nachos.sqlCon);
                        DataTable table2 = new DataTable();
                        adapt2.Fill(table2);
                        dataGridView2.DataSource = new BindingSource(table2, null);
                        nachos.sqlCon.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số chứng minh nhân dân để được coi danh sách đơn hàng!");
                }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menutaixe them = new menutaixe();
            them.ShowDialog();
            this.Close();
        }
    }
}

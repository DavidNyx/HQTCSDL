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
    public partial class taixetheodoidonhang : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public taixetheodoidonhang()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox1.Text != "")
                {
                    SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT cmnd from taixe where taixe.cmnd = '" + textBox1.Text + "' ", sqlConn);
                    DataTable table1 = new DataTable();
                    adapt1.Fill(table1);
                    if (table1.Rows.Count < 1)
                    {
                        MessageBox.Show("Tài xế không tồn tại!");
                    }
                    else
                    {
                        sqlConn.Open();
                        string cmnd = textBox1.Text;
                        SqlDataAdapter adapt = new SqlDataAdapter("exec VIEW_DONHANG '" + cmnd + "'", sqlConn);
                        DataTable table = new DataTable();
                        adapt.Fill(table);
                        dataGridView1.DataSource = new BindingSource(table, null);
                        sqlConn.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin tài xế để được coi danh sách sản phẩm!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //cmnd
        }
    }
}

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
    public partial class taixeconfirm : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        public taixeconfirm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox1.Text != "")
                {
                    //CHECK
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT taixe.cmnd from taixe where madoitac = '" + textBox1.Text + "' ", sqlConn);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    if (table.Rows.Count < 1)
                    {
                        MessageBox.Show("Bạn không phải tài xế!");
                    }
                    else
                    {
                        this.Hide();
                        taixetheodoidonhang theodoi = new taixetheodoidonhang();
                        theodoi.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            vaitro role = new vaitro();
            role.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

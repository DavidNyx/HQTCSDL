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
    public partial class doitacconfirm : Form
    {
        string connString = @"Data Source=DESKTOP-8PV3Q0P\SQLEXPRESS;Initial Catalog=DATH1;Integrated Security=True";
        public doitacconfirm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (textBox1.Text != "")
                {
                    //CHECK
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT doitac.madoitac from doitac where madoitac = '" + textBox1.Text + "' ", sqlConn);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    if (table.Rows.Count < 1)
                    {
                        MessageBox.Show("Bạn không phải đối tác!");
                    }
                    else
                    {
                        this.Hide();
                        menudoitac them = new menudoitac();
                        them.ShowDialog();
                        this.Close();
                    }    
                }
                else
                {
                    MessageBox.Show("Vui lòng điền thông tin!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            vaitro role = new vaitro();
            role.ShowDialog();
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQT_Project
{
    public partial class vaitro : Form
    {
        public vaitro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangky_khachhang buy = new dangky_khachhang();
            buy.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangky_doitac doitac = new dangky_doitac();
            doitac.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangky_taixe taixe = new dangky_taixe();
            taixe.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangky_nhanvien nhanvien = new dangky_nhanvien();
            nhanvien.ShowDialog();
            this.Close();
        }
    }
}

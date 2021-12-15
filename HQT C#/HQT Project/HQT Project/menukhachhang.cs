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
    public partial class menukhachhang : Form
    {
        public menukhachhang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            muahang_taohd doitac = new muahang_taohd();
            doitac.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {//xem don hang (chung voi tai xe)
            this.Hide();
            xemdonhang_khachhang theodoi = new xemdonhang_khachhang();
            theodoi.ShowDialog();
            this.Close();
        }
    }
}

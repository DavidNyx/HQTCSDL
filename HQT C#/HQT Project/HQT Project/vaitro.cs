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
            muahang_taohd buy = new muahang_taohd();
            buy.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            doitacconfirm doitac = new doitacconfirm();
            doitac.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            taixeconfirm taixe = new taixeconfirm();
            taixe.ShowDialog();
            this.Close();
        }
    }
}

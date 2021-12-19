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
    public partial class menutaixe : Form
    {
        public menutaixe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            capnhatdonhang_taixe them = new capnhatdonhang_taixe();
            them.ShowDialog();
            this.Close();
        }
    }
}

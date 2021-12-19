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
    public partial class menuadmin : Form
    {
        public menuadmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            kichhoat_admin them = new kichhoat_admin();
            them.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            quantri_admin them = new quantri_admin();
            them.ShowDialog();
            this.Close();
        }
    }
}

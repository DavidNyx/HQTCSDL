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
    public partial class menunhanvien : Form
    {
        public menunhanvien()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            nhanvienupdatehopdong them = new nhanvienupdatehopdong();
            them.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            nhanvienxemhdconhieuluc them = new nhanvienxemhdconhieuluc();
            them.ShowDialog();
            this.Close();
        }
    }
}

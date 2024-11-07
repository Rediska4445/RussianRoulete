using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parysov_ISP_223k___Russian_Roulete
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.numberOfMaxAmmo = trackBar3.Value;
            Form1.numberOfAmmo = trackBar2.Value;
            Form1.debug = checkBox1.Checked;
            Form1 frm = new Form1();
            Hide();
            frm.Show();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            
        }
    }
}

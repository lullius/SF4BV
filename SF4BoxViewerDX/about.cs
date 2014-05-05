using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SF4BoxViewerDX
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void about_Load(object sender, EventArgs e)
        {
            label1.Text = "SF4 Box Viewer v0.12" + Environment.NewLine + "Author: Lullius" + Environment.NewLine + "Homepage: www.slitherware.com";
        }

        private void bVisit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.slitherware.com");
        }

        private void bDonate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8GAGSQNCQP6M4");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

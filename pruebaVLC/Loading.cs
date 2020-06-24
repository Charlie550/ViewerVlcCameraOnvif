using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaVLC
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("loading.gif");            
            pictureBox1.Location = new Point(this.Width/2-pictureBox1.Width/2, this.Height / 2 - pictureBox1.Height / 2);
        }
    }
}

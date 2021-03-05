using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESS
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            gboSplash.Left = (this.Width - gboSplash.Width) / 2;
            gboSplash.Top = (this.Height - gboSplash.Height) / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {

                progressBar1.Value = progressBar1.Value + 20;
                lblProgress.Text = "Loading..." + progressBar1.Value + "%";

                if (progressBar1.Value == 100)
                {

                    FrmLogin login = new FrmLogin();
                    login.Visible = true;
                    //this.Hide();
                }
            }
        }
    }
}

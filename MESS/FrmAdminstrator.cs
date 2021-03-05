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
    public partial class FrmAdminstrator : Form
    {
        public FrmAdminstrator()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAdminstrator_Load(object sender, EventArgs e)
        {
            gboAdminstrator.Left = (this.Width - gboAdminstrator.Width) / 2;
            gboAdminstrator.Top = (this.Height - gboAdminstrator.Height) / 2;

        }
    }
}

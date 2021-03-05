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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            gboDash.Left = (this.Width - gboDash.Width) / 2;
            gboDash.Top= (this.Height - gboDash.Height) / 2;
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
         lblTimer.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void gboSplash2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gboDash_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin log = new FrmLogin();
            log.Visible = true;
            this.Close();
        }

        private void btnTips_Click(object sender, EventArgs e)
        {
            FrmTips tip = new FrmTips();
            tip.Visible = true;
            this.Hide();
        }

        private void btnOfficer_Click(object sender, EventArgs e)
        {
            FrmOfficer off = new FrmOfficer();
            off.Visible = true;
            this.Hide();
        }

        private void btnFarmer_Click(object sender, EventArgs e)
        {
            FrmFarmer fam = new FrmFarmer();
            fam.Visible = true;
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
            lblTimer.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*label2.Left = (this.Width - label2.Width) / 2;
            label2.Top = (this.Height - label2.Height) / 2;
            label3.Left = (this.Width - label3.Width) / 2;
            label3.Top = (this.Height - label3.Height) / 2;*/
           
        }
    }
}

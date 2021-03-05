using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace MESS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            gboLogin.Left = (this.Width - gboLogin.Width) / 2;
            gboLogin.Top = (this.Height - gboLogin.Height) / 2;
            txtEmailAdress.Focus();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
           Application.Exit();
            //this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmailAdress.Text = "";
            txtPassword.Text = "";
            txtEmailAdress.Focus();
        }

        private void Ctrl(object sender, KeyEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmailAdress.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailAdress.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    conn connect = new conn();
                    string query = "SELECT * FROM officer WHERE Email_Address='" + txtEmailAdress.Text.ToString() + "' AND Passsword='" + txtPassword.Text.ToString() + "' AND Status=1";
                    //open connection
                    if (connect.OpenConnection() == true)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        if (dataReader.Read())
                        {
                            /*MessageBox.Show("Login successful");
                            Dashboard das = new Dashboard();*/
                            FrmDashboard das = new FrmDashboard();
                            das.Visible = true;
                            this.Hide();
                        }

                        else
                        {
                            txtEmailAdress.Text = "";
                            txtPassword.Text = "";
                            txtEmailAdress.Focus();
                            MessageBox.Show("password/username mismatch!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            /*FrmOfficer off = new FrmOfficer();
            off.Visible = true;
            off.Hide();*/
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOfficer off = new FrmOfficer();
            off.Visible = true;
           this.Hide();
        }
    }
}

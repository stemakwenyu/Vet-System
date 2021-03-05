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
    public partial class FrmOfficer : Form
    {
        String query;
        String offcCode;
        public FrmOfficer()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmOfficer_Load(object sender, EventArgs e)
        {
            gboOfficer.Left = (this.Width - gboOfficer.Width) / 2;
            gboOfficer.Top = (this.Height - gboOfficer.Height) / 2;
            txtOfficerId.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            
        }
        private void Reset()
        {
            txtOfficerId.Text = "";
            txtEmailAddress.Text = "";
            txtFirstName.Text = "";
            txtIdNo.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNo.Text = "";
            txtPostalCode.Text = "";
            if (cboOfficerId.Visible == false)
            {
                cboOfficerId.Focus();
            }
            else
            {
                txtOfficerId.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            FrmDashboard das = new FrmDashboard();
            das.Visible = true;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //for deletion
            if (cboOfficerId.Visible == false)
            {
                MessageBox.Show("Select Details to Edit");
                cboOfficerId.Visible = true;
            }
            else if (MessageBox.Show("Are you sure you want to exit?", "MESS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query = "DELETE FROM officer WHERE Officer_Id='" + cboOfficerId.TabIndex + "'";
                try
                {
                    conn connect = new conn();
                    if (connect.OpenConnection() == true)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        cmd.ExecuteNonQuery();
                        connect.CloseConnection();
                        MessageBox.Show("Record Successfully deleted!", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboOfficerId.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboOfficerId.Visible= false;
            Reset();
            cboOfficerId.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOfficerId.Text == "" && cboOfficerId.Visible == false)
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOfficerId.Focus();
            }
            if (cboOfficerId.Text == "" && cboOfficerId.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboOfficerId.Focus();
            }
            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
            }
            
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
            }
            else if (txtEmailAddress.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailAddress.Focus();
            }
            else if (txtPostalCode.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostalCode.Focus();
            }
            else if (txtIdNo.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdNo.Focus();
            }
            
            else if (txtPhoneNo.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNo.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else if (cboStatus.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboStatus.Focus();
            }
            
            else
            {
                if (cboOfficerId.Visible == true)
                {

                    query = "UPDATE officer SET Officer_Id='" + cboOfficerId.Text + "', F_Name='" + txtFirstName.Text + "', L_Name= '" + txtLastName.Text + "', Email_Address='" + txtEmailAddress.Text + "', Postal_Code='" + txtPostalCode.Text + "', IdNo='" + txtIdNo.Text + "',Phone_No='" + txtPhoneNo.Text + "', Passsword='" + txtPassword.Text + "',Status='" + cboStatus.Text + "' WHERE Officer_Id= '" + offcCode + "'";

                }

                else
                {

                    query = "INSERT INTO officer(Officer_Id, F_Name, L_Name,Email_Address, Postal_Code, IdNo, Phone_No, Passsword, Status) VALUES('" + txtOfficerId.Text + "', '" + txtFirstName.Text + "',, '" + txtLastName.Text + "' ,'" + txtEmailAddress.Text + "','" + txtPostalCode.Text + "', '" + txtIdNo.Text + "', '" + txtPhoneNo.Text + "', '" + txtPassword.Text + "', '" + cboStatus.Text + "')";

                }
                try
                {
                    conn connect = new conn();
                    if (connect.OpenConnection() == true)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        //MySqlDataReader dataReader 
                        cmd.ExecuteReader();
                        connect.CloseConnection();
                        MessageBox.Show("Record Successfully saved!", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.Filter = "Choose image(*.jpg;*.gif;*png)|*.jpg;*.gif;*.png";
            if (pic.ShowDialog() == DialogResult.OK)
            {
                picPassPort.Image = Image.FromFile(pic.FileName);
            }
        }
    }
}

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
    public partial class FrmFarmer : Form
    {
        String query;
        string famCode;
        public FrmFarmer()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmFarmer_Load(object sender, EventArgs e)
        {
            gboFarmer.Left = (this.Width - gboFarmer.Width) / 2;
            gboFarmer.Top = (this.Height - gboFarmer.Height) / 2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFarmerId.Text == "" && cboFarmerId.Visible == false)
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFarmerId.Focus();
            }
            if (cboFarmerId.Text == "" && cboFarmerId.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboFarmerId.Focus();
            }
            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
            }
            else if (txtMiddleName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMiddleName.Focus();
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
            }
            
            else if (txtPostalCode.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostalCode.Focus();
            }
            else if (txtEmailAddress.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailAddress.Focus();
            }
            else if (txtPhoneNo.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNo.Focus();
            }
            else if (cboStatus.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboStatus.Focus();
            }
            else if (txtTipCode.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTipCode.Focus();
            }
            else if (txtOfficerId.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOfficerId.Focus();
            }



            else
            {
                if (cboFarmerId.Visible == true)
                {

                    query = "UPDATE farmer SET Farmer_Id='" + cboFarmerId.Text + "', F_Name='" + txtFirstName.Text + "', M_Name= '" + txtMiddleName.Text + "', L_Name= '" + txtLastName.Text + "', Postal_Code='" + txtPostalCode.Text + "', Email_Address='" + txtEmailAddress.Text + "', Phone_No='" + txtPhoneNo.Text + "', Status='" + cboStatus.Text + "', Tip_Code='" + txtTipCode.Text + "', Officer_Id='" + txtOfficerId.Text + "' WHERE Farmer_Id= '" + famCode + "'";

                }

                else
                {

                    query = "INSERT INTO farmer(Farmer_Id, F_Name, M_Name, L_Name,Postal_Code, Email_Address, Phone_No, Status,Tip_Code,Officer_Id) VALUES('" + txtFarmerId.Text + "', '" + txtFirstName.Text + "', '" + txtMiddleName.Text + "',, '" + txtLastName.Text + "' '" + txtPostalCode.Text + "', '" + txtEmailAddress.Text + "', '" + txtPhoneNo.Text + "', '" + cboStatus.Text + "', '" + txtTipCode.Text + "', '" + txtOfficerId.Text + "')";

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

        private void btnReset_Click(object sender, EventArgs e)
        {

            Reset();
        }
        private void Reset()
        {
            txtFarmerId.Text = "";
            txtEmailAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtOfficerId.Text = "";
            txtPostalCode.Text = "";
            txtTipCode.Text = "";
            cboStatus.Text = "";
            txtPhoneNo.Text = "";
            txtFarmerId.Focus();
            if (cboFarmerId.Visible == false)
            {
                cboFarmerId.Focus();
            }
            else
            {
                txtFarmerId.Focus();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboFarmerId.Visible = false;
            Reset();
            cboFarmerId.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           cboFarmerId.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //for deletion
            if (cboFarmerId.Visible == false)
            {
                MessageBox.Show("Select Details to Edit");
                cboFarmerId.Visible = true;
            }
            else if (MessageBox.Show("Are you sure you want to exit?", "MESS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query = "DELETE FROM farmer WHERE Farmer_Id='" + cboFarmerId.TabIndex + "'";
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            FrmDashboard das = new FrmDashboard();
            das.Visible = true;
            this.Close();
            
            
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

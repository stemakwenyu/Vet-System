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
    public partial class FrmTips : Form
    {
        String query;
        String tipCode;
        public FrmTips()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmTips_Load(object sender, EventArgs e)
        {
            gboTips.Left = (this.Width - gboTips.Width) / 2;
            gboTips.Top = (this.Height - gboTips.Height) / 2;
            txtTipCode.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboTipCode.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cboTipCode.Visible = false;
            Reset();
            cboTipCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTipCode.Text == "" && cboTipCode.Visible == false)
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTipCode.Focus();
            }
            else if (cboTipCode.Text == "" && cboTipCode.Visible == true)
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipCode.Focus();
            }
            else if (cboTipType.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipType.Focus();
            }
            else if (dtpTime.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpTime.Focus();
            }
            else if (rtxtDescription.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtDescription.Focus();
            }

            else
            {
                if (cboTipCode.Visible == true)
                {

                    query = "UPDATE Tip SET Tip_Code='" + cboTipCode.Text + "', Tip_Type='" + cboTipType.Text + "', Time_Interval= '" + dtpTime.Text + "', Description= '" + rtxtDescription.Text + "' WHERE Tip_Code= '" + tipCode + "'";

                }

                else
                {

                    query = "INSERT INTO tip(Tip_Code, Tip_Type, Time_Interval, Description) VALUES('" + txtTipCode.Text+ "', '" + cboTipType.Text + "', '" + dtpTime.Text + "',, '" + rtxtDescription.Text + "')";

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
            txtTipCode.Text = "";
            rtxtDescription.Text = "";
            cboTipType.Text = "";
            if (cboTipCode.Visible == false)
            {
                cboTipCode.Focus();
            }
            else
            {
                txtTipCode.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            FrmDashboard das = new FrmDashboard();
            das.Visible = true;
            this.Close();
        }

        private void cboTipCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboTipCode.Text == "")
            {
                MessageBox.Show("Ensure that all fields are filled!", "MESS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipCode.Focus();
            }
            else
            {

                conn connect = new conn();
                if (connect.OpenConnection() == true)
                {
                    query = "SELECT * FROM tip WHERE Tip_Code LIKE '" + cboTipCode.Text + "' ORDER BY Tip_Code ASC";
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Read the data and store them in the list

                    if (dataReader.Read())
                    {

                        this.cboTipType.Text = dataReader["Tip_Type"].ToString();
                        this.dtpTime.Text = dataReader["Time_Interval"].ToString();
                        this.rtxtDescription.Text = dataReader["Description"].ToString();
                        
                        tipCode = dataReader["Tip_Code"].ToString();       //for editing


                    }
                    connect.CloseConnection();
                }

            }
        }
    }
}

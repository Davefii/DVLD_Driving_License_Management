using BussinesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace dvld
{
    public partial class UpdateApplicationType : Form
    {
        int _ID;
        clsApplicationTypes _Applications;
        public UpdateApplicationType(int Id)
        {
            InitializeComponent();
            _ID = Id;
        }
        private void _LoadData()
        {
            _Applications = clsApplicationTypes.Find(_ID);
            if (_Applications == null)
            {
                MessageBox.Show("Application is Null","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                lblID.Text = _Applications.ID.ToString();
                txtTypes.Text = _Applications.ApplicationTitleTypes;
                txtfees.Text = _Applications.ApplicationTypesFee.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtfees.Text, out int fee))
            {
                MessageBox.Show("Please enter a valid number for the fee.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _Applications.ApplicationTitleTypes = txtTypes.Text.Trim();
            _Applications.ApplicationTypesFee = fee/*(int)Convert.ToSingle(txtfees.Text.Trim())*/;
            if (_Applications.Save())
            {
                MessageBox.Show("Application updated successfully",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();   // optionally close the form on success
            }
            else
            {
                MessageBox.Show("Failed to update application",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}

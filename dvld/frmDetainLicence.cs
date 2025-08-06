using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dvld
{
    public partial class frmDetainLicence : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenceID = -1;
        public frmDetainLicence()
        {
            InitializeComponent();
        }

        private void frmDetainLicence_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.userName;
        }

        private void ctrlDriverLicenseInfoWithFilterControl1_OnLicenseSelected(int obj)
        {
            _SelectedLicenceID = obj;
            lblLicenseID.Text = _SelectedLicenceID.ToString();
            llShowLicenseHistory.Enabled = (_SelectedLicenceID != -1);
            if (_SelectedLicenceID == -1)
            {
                return;
            }
            if (ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFineFees.Focus();
            button1.Enabled = true;
        }

        private void frmDetainLicence_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilterControl1.txtLicenseIDFocus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _DetainID = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.CurrentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button1.Enabled = false;
            ctrlDriverLicenseInfoWithFilterControl1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DriverInfo.PersonID);
            licenseHistory.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo showLicenseInfo = new frmShowLicenseInfo(_SelectedLicenceID);
            showLicenseInfo.ShowDialog();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            }
            
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, control characters (like backspace), and decimal point
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the keystroke
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

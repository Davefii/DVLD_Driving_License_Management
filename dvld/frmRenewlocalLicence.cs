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

namespace dvld
{
    public partial class frmRenewlocalLicence : Form
    {
        private int _NewLicenseID = -1;
        public frmRenewlocalLicence()
        {
            InitializeComponent();
        }

        private void frmRenewlocalLicence_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilterControl1.txtLicenseIDFocus();

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationTypesFee.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.userName;

        }

        private void ctrlDriverLicenseInfoWithFilterControl1_OnLicenseSelected(int obj)
        {
            int SelectedLicenceId = obj;
            lblOldLicenseID.Text = SelectedLicenceId.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenceId != -1);
            if (SelectedLicenceId == -1)
            {
                return;
            }
            lblExpirationDate.Text = DateTime.Now.AddYears(ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.Notes;

            //check the license is not Expired.
            if (!ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.ExpirationDate.ToShortTimeString()
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }

            //check the license is not Active.
            if (!ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }

            btnRenewLicense.Enabled = true;
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsLicence NewLicence = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);
            if (NewLicence == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
            lblApplicationID.Text = NewLicence.ApplicationID.ToString();
            _NewLicenseID = NewLicence.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            btnRenewLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilterControl1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo showLicenseInfo = new frmShowLicenseInfo(_NewLicenseID);
            showLicenseInfo.ShowDialog();
        }

        private void frmRenewlocalLicence_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilterControl1.txtLicenseIDFocus();
        }
    }
}

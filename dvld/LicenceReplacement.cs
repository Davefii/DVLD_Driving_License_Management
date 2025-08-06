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
using static BussinesLayer.clsLicence;

namespace dvld
{
    public partial class LicenceReplacement : Form
    {
        private int _NewLicenseID = -1;
        public LicenceReplacement()
        {
            InitializeComponent();
        }
        private int _GetApplicationTypeID()
        {
            //this will decide which application type to use accirding 
            // to user selection.

            if (rbDamagedLicense.Checked)

                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rbDamagedLicense.Checked)

                return enIssueReason.Damegereplacement;
            else
                return enIssueReason.Lostreplasment;
        }

        private void LicenceReplacement_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.userName;

            rbDamagedLicense.Checked = true;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "Replacement for Damaged License";
            this.Text = label3.Text;
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationTypesFee.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "Replacement for Lost License";
            this.Text = label3.Text;
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationTypesFee.ToString();
        }

        private void ctrlDriverLicenseInfoWithFilterControl1_OnLicenseSelected(int obj)
        {
            int SelectedLicenceID = obj;
            lblOldLicenseID.Text = SelectedLicenceID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenceID != -1);
            if (SelectedLicenceID == -1)
            {
                return;
            }
            //dont allow a replacement if is not Active .
            if (!ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicence NewLicense = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsGlobal.CurrentUser.UserID);
            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblRreplacedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctrlDriverLicenseInfoWithFilterControl1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo showLicenseInfo = new frmShowLicenseInfo(_NewLicenseID);
            showLicenseInfo.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Not Implemented Yet !!!!!!!");
        }
    }
}

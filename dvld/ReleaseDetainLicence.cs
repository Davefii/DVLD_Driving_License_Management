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
    public partial class ReleaseDetainLicence : Form
    {
        private int _SelectedLicenceID = -1;
        public ReleaseDetainLicence()
        {
            InitializeComponent();
        }
        public ReleaseDetainLicence(int LicenceID)
        {
            InitializeComponent();
            _SelectedLicenceID = LicenceID;
            ctrlDriverLicenseInfoWithFilterControl1.LoadLicenseInfo(_SelectedLicenceID);
            ctrlDriverLicenseInfoWithFilterControl1.FilterEnabled = false;
        }

        private void ctrlDriverLicenseInfoWithFilterControl1_OnLicenseSelected(int obj)
        {
            _SelectedLicenceID = obj;
            llShowLicenseHistory.Enabled = (_SelectedLicenceID != -1);
            if (_SelectedLicenceID == -1)
            {
                return;
            }
            if (!ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationTypesFee.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.userName;

            lblDetainID.Text = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.LicenseID.ToString();

            lblCreatedByUser.Text = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.userName;
            lblDetainDate.Text = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToShortDateString();
            lblFineFees.Text = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;

            bool isReleased = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID);
            lblApplicationID.Text = ApplicationID.ToString();
            if (!isReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilterControl1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo showLicenseInfo = new frmShowLicenseInfo(_SelectedLicenceID);
            showLicenseInfo.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DriverInfo.PersonID);
            licenseHistory.ShowDialog();
        }
    }
}

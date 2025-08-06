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
    public partial class AddinternationalLicence : Form
    {
        private int _InternationalLicenseID = -1;
        public AddinternationalLicence()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilterControl1_OnLicenseSelected(int obj)
        {
            int SelectedLicenceID = obj;
            lblLocalLicenseID.Text = SelectedLicenceID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenceID != -1);
            if (SelectedLicenceID == -1)
            {
                return;
            }
            if (ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License should be Active, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ActiveinternationalLicenceID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(SelectedLicenceID);
            if (ActiveinternationalLicenceID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveinternationalLicenceID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveinternationalLicenceID;
                btnIssueLicense.Enabled = false;
                return;
            }
            btnIssueLicense.Enabled = true;
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypesFee;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilterControl1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void AddinternationalLicence_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();//add one year.
            lblFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypesFee.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.userName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddinternationalLicence_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilterControl1.txtLicenseIDFocus();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicence internationalLicence = new frmInternationalLicence(_InternationalLicenseID);
            internationalLicence.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicneceID = ctrlDriverLicenseInfoWithFilterControl1.SelectedLicenseInfo.LicenseID;
            frmLicenseHistory licenseHistory = new frmLicenseHistory(LicneceID);
            licenseHistory.ShowDialog();
        }
    }
}

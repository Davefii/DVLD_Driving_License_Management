using BussinesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dvld
{
    public partial class Form1 : Form
    {
        Log _frmlogin;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Log Login)
        {
            InitializeComponent();
            _frmlogin = Login;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form form2 = new ManagePeople();
            form2.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(clsGlobal.CurrentUser.PersonID);
            form4.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(clsGlobal.CurrentUser.UserID);
            changePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Log log = new Log();
            log.Show();
        }

        private void drivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplication manageApplication = new ManageApplication();
            manageApplication.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypes manageTestTypes = new ManageTestTypes();
            manageTestTypes.ShowDialog();
        }

        private void localDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrUpdateLocalDrivingLicenseApplication addorUpdateLocalDrivingLicenseApplication = new AddOrUpdateLocalDrivingLicenseApplication();
            addorUpdateLocalDrivingLicenseApplication.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalLicence manageLocalLicence = new ManageLocalLicence();
            manageLocalLicence.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalLicence manageLocalLicence = new ManageLocalLicence();
            manageLocalLicence.ShowDialog();
        }

        private void renewLocalDrivngLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewlocalLicence renewlocalLicence = new frmRenewlocalLicence();
            renewlocalLicence.ShowDialog();
        }

        private void replacmentDamegedOrLostLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceReplacement replacment = new LicenceReplacement();
            replacment.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listDrivers drivers = new listDrivers();
            drivers.ShowDialog();
        }

        private void detainLicecnceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicence detainLicence = new frmDetainLicence();
            detainLicence.ShowDialog();
        }

        private void relaeseDetainedDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainLicence releaseDetainLicence = new ReleaseDetainLicence();
            releaseDetainLicence.ShowDialog();
        }

        private void releaseDetainedLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainLicence releaseDetainLicence = new ReleaseDetainLicence();
            releaseDetainLicence.ShowDialog();
        }

        private void manageDetainedLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDetainedLicence manageDetainedLicence = new ManageDetainedLicence();
            manageDetainedLicence.ShowDialog();
        }

        private void internationalDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddinternationalLicence addinternational = new AddinternationalLicence();
            addinternational.ShowDialog();
        }

        private void addNewInternationalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddinternationalLicence addinternational = new AddinternationalLicence();
            addinternational.ShowDialog();
        }

        private void manageInternationalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListInternationalLicence listInternationalLicence = new ListInternationalLicence();
            listInternationalLicence.ShowDialog();
        }
    }
}

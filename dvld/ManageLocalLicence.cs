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
    public partial class ManageLocalLicence : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApplications;
        public ManageLocalLicence()
        {
            InitializeComponent();
        }
        private void _ReferchContent()
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dataGridView1.DataSource = _dtAllLocalDrivingLicenseApplications;
            lblcount.Text = dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "L.D.L.AppID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Driving Class";
                dataGridView1.Columns[1].Width = 300;

                dataGridView1.Columns[2].HeaderText = "National No.";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 350;

                dataGridView1.Columns[4].HeaderText = "Application Date";
                dataGridView1.Columns[4].Width = 170;

                dataGridView1.Columns[5].HeaderText = "Passed Tests";
                dataGridView1.Columns[5].Width = 150;
            }
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterBy.Text == "None");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddOrUpdateLocalDrivingLicenseApplication addOrUpdateLocalDrivingLicenseApplication = new AddOrUpdateLocalDrivingLicenseApplication();
            addOrUpdateLocalDrivingLicenseApplication.ShowDialog();
            ManageLocalLicence_Load(null, null);
        }
        private void ManageLocalLicence_Load(object sender, EventArgs e)
        {
            _ReferchContent();
        }
        private void editAppliactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrUpdateLocalDrivingLicenseApplication addOrUpdateLocalDrivingLicenseApplication = new AddOrUpdateLocalDrivingLicenseApplication((int)dataGridView1.CurrentRow.Cells[0].Value);
            addOrUpdateLocalDrivingLicenseApplication.ShowDialog();
            ManageLocalLicence_Load(null, null);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = "";
            switch(cbFilterBy.Text)
            {
                case "L.D.L.App1D":
                    filterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    filterColumn = "NationalNo";
                    break;
                case "Full Name":
                    filterColumn = "FullName";
                    break;
                case "Status":
                    filterColumn = "Status";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || filterColumn == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblcount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            if (filterColumn == "LocalDrivingLicenseApplicationID")
                //in this case we deal with integer not string.
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, txtFilterValue.Text.Trim());

            lblcount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
                txtFilterValue.Text = "";
            }
            else
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            else
            {
                int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
                if (localDrivingLicenseApplication != null)
                {
                    localDrivingLicenseApplication.Delete();
                    MessageBox.Show("Application Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageLocalLicence_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Error in deleting the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ManageLocalLicence_Load(null, null);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            else
            {
                int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
                if (localDrivingLicenseApplication != null)
                {
                    localDrivingLicenseApplication.Cancel();
                    MessageBox.Show("Application Cancelled Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageLocalLicence_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Error in Cancel the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ManageLocalLicence_Load(null, null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenceInformation frmLocalDrivingLicenceInformation =
                 new frmLocalDrivingLicenceInformation((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmLocalDrivingLicenceInformation.ShowDialog();
            ManageLocalLicence_Load(null, null);
        }

        private void visonTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListAppointments listAppointments = new ListAppointments((int)dataGridView1.CurrentRow.Cells[0].Value,clsTestTypes.enTestType.VisionTest);
            listAppointments.ShowDialog();
            ManageLocalLicence_Load(null, null);
        }

        private void writeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListAppointments listAppointments = new ListAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.WrittenTest);
            listAppointments.ShowDialog();
            ManageLocalLicence_Load(null, null);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListAppointments listAppointments = new ListAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.StreetTest);
            listAppointments.ShowDialog();
            ManageLocalLicence_Load(null, null);
        }

        private void issueDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmIssueLicenceFirstime issueLicenceFirstime = new frmIssueLicenceFirstime(LocalDrivingLicenseApplicationID);
            issueLicenceFirstime.ShowDialog();
            ManageLocalLicence_Load(null,null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenceID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenceID);
            int TotalPassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            bool LicenseExists = localDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            issueDrivingLicenceToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenceToolStripMenuItem.Enabled = LicenseExists;
            editAppliactionToolStripMenuItem.Enabled = !LicenseExists && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            scToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteApplicationToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisonTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
            bool PassedwirtenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);
            scToolStripMenuItem.Enabled = (!PassedVisonTest || !PassedwirtenTest || !PassedStreetTest) && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (scToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                visonTestToolStripMenuItem.Enabled = !PassedVisonTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                writeTestToolStripMenuItem.Enabled = PassedVisonTest && !PassedwirtenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                streetTestToolStripMenuItem.Enabled = PassedVisonTest && PassedwirtenTest && !PassedStreetTest;
            }
        }

        private void showLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int LicenceID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID).GetActiveLicenseID();
            if (LicenceID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenceID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showPersonLicenceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PersonID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID).ApplicantPersonID;
            frmLicenseHistory licenseHistory = new frmLicenseHistory(PersonID);
            licenseHistory.ShowDialog();
        }
    }
}

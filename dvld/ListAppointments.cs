using BussinesLayer;
using dvld.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BussinesLayer.clsTestTypes;

namespace dvld
{
    public partial class ListAppointments : Form
    {
        private DataTable _dtLocalTestAppointment;
        private int _LocalDrivingLicenceApplicationID = -1;
        private clsTestTypes.enTestType _testType = clsTestTypes.enTestType.VisionTest;
        public ListAppointments(int LocalDrivingLicenceApplicationID, clsTestTypes.enTestType testType)
        {
            InitializeComponent();
            _LocalDrivingLicenceApplicationID = LocalDrivingLicenceApplicationID;
            _testType = testType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_testType)
            {

                case clsTestTypes.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestTypes.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Street_test_512;
                        break;
                    }
            }
        }
        private void ListAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            ctrlDrivingLicenceInformation1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenceApplicationID);
            _dtLocalTestAppointment = clsTestAppoitment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenceApplicationID, _testType);
            dataGridView1.DataSource = _dtLocalTestAppointment;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 150;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 100;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenceApplicationID);
            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_testType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_testType);
            if (LastTest == null)
            {
                frmSchudueletest schudueletest = new frmSchudueletest(_LocalDrivingLicenceApplicationID, _testType);
                schudueletest.ShowDialog();
                ListAppointments_Load(null, null);
                return;
            }
            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmSchudueletest frm2 = new frmSchudueletest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _testType);
            frm2.ShowDialog();
            ListAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmSchudueletest frm = new frmSchudueletest(_LocalDrivingLicenceApplicationID, _testType, TestAppointmentID);
            frm.ShowDialog();
            ListAppointments_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmTakeTest takeTest = new frmTakeTest(TestAppointmentID, _testType);
            takeTest.ShowDialog();
            ListAppointments_Load(null, null);
        }
    }
}

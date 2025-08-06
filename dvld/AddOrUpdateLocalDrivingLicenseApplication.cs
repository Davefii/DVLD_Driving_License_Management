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
    public partial class AddOrUpdateLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1};
        private enMode _Mode;
        private int _LocatDrivingLicenseApp1icationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalLicenceApplication;
        
        public AddOrUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public AddOrUpdateLocalDrivingLicenseApplication(int LocatDrivingLicenseApp1icationID)
        {
            InitializeComponent();
            _LocatDrivingLicenseApp1icationID = LocatDrivingLicenseApp1icationID;
            _Mode = enMode.Update;
        }
        private void _FillComboboxinLicenceClass()
        {
            DataTable LicenceClass = clsLicenceClass.GetAllLicenceClass();
            foreach (DataRow Row in LicenceClass.Rows)
            {
                comboBox2.Items.Add(Row["ClassName"]);
            }
        }
        private void _ResetDefaultValue()
        {
            _FillComboboxinLicenceClass();

            if (_Mode == enMode.AddNew)
            {
                lbltitle.Text = "New Locat Driving Licence Application";
                this.Text = "New Local Driving Licence Application";
                _LocalLicenceApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCartWithFilterControl1.FilterFocus();
                tabPage2.Enabled = false;

                comboBox2.SelectedIndex = 2;
                labelforfees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationTypesFee.ToString();                
                labelforDate.Text = DateTime.Now.ToShortDateString();
                labelforuser.Text = clsGlobal.CurrentUser.userName;
            }
            else
            {
                lbltitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tabPage2.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void _LoadData()
        {
            ctrlPersonCartWithFilterControl1.FilterEnabled = false;
            _LocalLicenceApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocatDrivingLicenseApp1icationID);
            if (_LocalLicenceApplication == null)
            {
                MessageBox.Show("No Application With ID = " + _LocatDrivingLicenseApp1icationID, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlPersonCartWithFilterControl1.LoadPersonInfo(_LocalLicenceApplication.ApplicantPersonID);
            labelforApplicationID.Text = _LocalLicenceApplication.LocalDrivingLicenseApplicationID.ToString();
            labelforDate.Text = _LocalLicenceApplication.ApplicationDate.ToShortDateString();
            comboBox2.SelectedIndex = comboBox2.FindString(clsLicenceClass.FindByID(_LocalLicenceApplication.LicenseClassID).ClassName);
            labelforfees.Text = _LocalLicenceApplication.PaidFees.ToString();
            labelforuser.Text = clsPerson.clsUser.Find(_LocalLicenceApplication.CreatedByUserID).ToString();
        }
        private void DavaBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlPersonCartWithFilterControl1.LoadPersonInfo(PersonID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseCIassID = clsLicenceClass.FindByName(comboBox2.Text).LicenseClassID;
            int ActiveApplicatinID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseCIassID);
            if (ActiveApplicatinID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicatinID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Focus();
                return;
            }
            //check if user already have issued license of the same driving  class.
            //Create This Later
            _LocalLicenceApplication.ApplicantPersonID = ctrlPersonCartWithFilterControl1.PersonID; ;
            _LocalLicenceApplication.ApplicationDate = DateTime.Now;
            _LocalLicenceApplication.ApplicationTypeID = 1;
            _LocalLicenceApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalLicenceApplication.LastStatusDate = DateTime.Now;
            _LocalLicenceApplication.PaidFees = Convert.ToSingle(labelforfees.Text);
            _LocalLicenceApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalLicenceApplication.LicenseClassID = LicenseCIassID;
            if (_LocalLicenceApplication.Save())
            {
                labelforApplicationID.Text = _LocalLicenceApplication.ApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lbltitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddOrUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.Update)
                _LoadData();
        }
        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCartWithFilterControl1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                return;
            }
            //incase of add new mode.
            if (ctrlPersonCartWithFilterControl1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCartWithFilterControl1.FilterFocus();
            }
        }

        private void ctrlPersonCartWithFilterControl1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void AddOrUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCartWithFilterControl1.FilterFocus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

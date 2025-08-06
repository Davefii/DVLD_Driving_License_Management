using BussinesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dvld
{
    public partial class ctrlDriverLoaclLicenceInformation : UserControl
    {
        private int _LicenceID;
        private clsLicence _Licence;

        public ctrlDriverLoaclLicenceInformation()
        {
            InitializeComponent();
        }
        public int LicenceID
        {
            get { return _LicenceID; }
        }
        public clsLicence SelectedLicenceInfo
        {
            get { return _Licence; }
        }
        private void _LoadPersonInfo()
        {
            if (_Licence.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
            string ImagePath = _Licence.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void LoadLicenceInfo(int LicenceID)
        {
            _LicenceID = LicenceID;
            _Licence = clsLicence.Find(_LicenceID);
            if (_Licence == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenceID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenceID = -1;
                return;
            }
            lblClass.Text = _Licence.LicenseClassInfo.ClassName;
            lblFullName.Text = _Licence.DriverInfo.PersonInfo.FullName;
            lblDriverID.Text = _Licence.LicenseID.ToString();
            lblNationalNo.Text = _Licence.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _Licence.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = _Licence.IssueDate.ToShortTimeString();
            lblIssueReason.Text = _Licence.IssueReasonText;
            lblNotes.Text = _Licence.Notes;
            lblIsActive.Text = _Licence.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _Licence.DriverInfo.PersonInfo.DateOfBirth.ToShortTimeString();
            lblDriverID.Text = _Licence.DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = _Licence.ExpirationDate.ToShortTimeString();
            lblIsDetained.Text = _Licence.IsDetained ? "Yes" : "No";
            _LoadPersonInfo();
        }
    }
}

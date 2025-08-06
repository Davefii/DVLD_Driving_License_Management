using BussinesLayer;
using Country;
using dvld.Properties;
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
    public partial class ctrlPersonInformation : UserControl
    {
        private clsPerson _Perosn;
        private int _PerosnId;
        public int PersonID
        { get { return _PerosnId; } }
        public clsPerson SelectedPerson
        { get { return _Perosn; }}
        public ctrlPersonInformation()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _PerosnId = PersonID;
            _Perosn = clsPerson.Find(_PerosnId);
            if (_Perosn == null)
            {
                MessageBox.Show("No Person with PersonID" + PersonID.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _FillPerosnInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Perosn = clsPerson.Find(NationalNo);
            if (_Perosn == null)
            {
                MessageBox.Show("This Person Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPerosnInfo();
        }
        private void _LoadPersonImgae()
        {
            if (_Perosn.Gendor == 0)
                pictureBox1.Image = Resources.Male_512;
            else
                pictureBox1.Image = Resources.Female_512;
            if (_Perosn.ImagePath != "")
            {
                if (File.Exists(_Perosn.ImagePath))
                    pictureBox1.ImageLocation = _Perosn.ImagePath;
                else
                    MessageBox.Show("Could Not Find this Image: = " + _Perosn.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddOrUpdatePeople addOrUpdatePeople = new AddOrUpdatePeople(_PerosnId);
            addOrUpdatePeople.ShowDialog();
            LoadPersonInfo(_PerosnId);
        }
        private void _FillPerosnInfo()
        {
            llEditPersonInfo.Enabled = true;
            lblid.Text = _Perosn.ID.ToString();
            lblFullName.Text = _Perosn.FullName;
            lblNacionalNo.Text = _Perosn.NationalNo;
            lblGender.Text = _Perosn.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _Perosn.Email;
            lblAddress.Text = _Perosn.Address;
            lbldateobbirth.Text = _Perosn.DateOfBirth.ToString("d");
            lblPhoneNumber.Text = _Perosn.Phone;
            lblCountry.Text = clsCountry.FindByID(_Perosn.NationalityCountryID).CountryName;
            _LoadPersonImgae();
        }
    }
}

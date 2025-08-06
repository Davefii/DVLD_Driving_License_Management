using BussinesLayer;
using Country;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dvld
{
    public partial class AddOrUpdatePeople : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonIO);
        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _personID;
        clsPerson _person;
        public AddOrUpdatePeople()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public AddOrUpdatePeople(int PersonID)
        {
            InitializeComponent();
            _personID = PersonID;
            _Mode = enMode.Update;
        }
        private void _FillComboBoxCountry()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }
        }
        private void _reastDefaultValue()
        {
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");
            rbMale.Checked = true;
            if (rbMale.Checked)
                pictureBox1.Image = Properties.Resources.Male_512;
            else
                pictureBox1.Image = Properties.Resources.Female_512;
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);
            TxtNationalNO.Text = "";
            TxtFirstName.Text = "";
            TxtSecondName.Text = "";
            TxtThirdName.Text = "";
            TxtLastName.Text = "";
        }
        private void _LoadData()
        {
            _FillComboBoxCountry();
            _reastDefaultValue();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _person = new clsPerson();
                return;
            }
            else
            {
                _person = clsPerson.Find(_personID);
                if (_person == null)
                {
                    MessageBox.Show(" No Contact with ID = " + _personID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblTitle.Text = "Update Person :";
                lblid.Text = _person.ID.ToString();
                TxtNationalNO.Text = _person.NationalNo;
                TxtFirstName.Text = _person.FirstName;
                TxtSecondName.Text = _person.SecondName;
                TxtThirdName.Text = _person.ThirdName;
                TxtLastName.Text = _person.LastName;
                //dateTimePicker1.Value = _person.DateOfBirth;
                if (_person.DateOfBirth >= dateTimePicker1.MinDate && _person.DateOfBirth <= dateTimePicker1.MaxDate)
                    dateTimePicker1.Value = _person.DateOfBirth;
                else
                    dateTimePicker1.Value = DateTime.Today; // or any default valid date
                if (_person.Gendor == 0)
                {
                    rbFemale.Checked = false;
                    rbMale.Checked = true;
                }
                else
                {
                    rbMale.Checked = false;
                    rbFemale.Checked = true;
                }
                TxtEmail.Text = _person.Email;
                TxtAddress.Text = _person.Address;
                if (_person.ImagePath != "")
                {
                    pictureBox1.Load(_person.ImagePath);
                }
                linkLabel2.Visible = (_person.ImagePath != "");
                //this will select the country in the combobox.
                cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.FindByID(_person.NationalityCountryID).CountryName);
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pictureBox1.Load(selectedFilePath);
                // ...
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            linkLabel2.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.FindByName(cbCountry.Text).ID;
            _person.NationalNo = TxtNationalNO.Text.Trim();
            _person.FirstName = TxtFirstName.Text.Trim();
            _person.SecondName = TxtSecondName.Text.Trim();
            _person.ThirdName = TxtThirdName.Text.Trim();
            _person.LastName = TxtLastName.Text.Trim();
            _person.Email = TxtEmail.Text.Trim();
            _person.Phone = maskedTextBox2.Text.Trim();
            _person.Address = TxtAddress.Text.Trim();
            _person.DateOfBirth = dateTimePicker1.Value;
            _person.NationalityCountryID = CountryID;
            _person.Gendor = rbMale.Checked ? (int)0 : (rbFemale.Checked ? (int)1 : 0);
            if (pictureBox1.ImageLocation != null)
                _person.ImagePath = pictureBox1.ImageLocation;
            else
                _person.ImagePath = "";

            if (_person.save())
            {
                MessageBox.Show("Data Saved Successfully.");
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person ID = " + _person.ID;
                lblid.Text = _person.ID.ToString();
                TxtNationalNO.Text = _person.NationalNo;
                TxtFirstName.Text = _person.FirstName;
                TxtSecondName.Text = _person.SecondName;
                TxtThirdName.Text = _person.ThirdName;
                TxtLastName.Text = _person.LastName;
                //dateTimePicker1.Value = _person.DateOfBirth;
                if (_person.DateOfBirth >= dateTimePicker1.MinDate && _person.DateOfBirth <= dateTimePicker1.MaxDate) { dateTimePicker1.Value = _person.DateOfBirth; }
                else { dateTimePicker1.Value = DateTime.Today; /* or any default valid date*/}
                if (_person.Gendor == 0) { rbFemale.Checked = false; rbMale.Checked = true; }
                else { rbMale.Checked = false; rbFemale.Checked = true; }
                TxtEmail.Text = _person.Email;
                TxtAddress.Text = _person.Address;
                if (_person.ImagePath != "") { pictureBox1.Load(_person.ImagePath); }
                linkLabel2.Visible = (_person.ImagePath != "");
                //this will select the country in the combobox.
                cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.FindByID(_person.NationalityCountryID).CountryName);
            }
            else
                MessageBox.Show("❌ Error: Data update failed.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DataBack?.Invoke(this, _person.ID);
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Female_512;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text))
            {
                e.Cancel = true;
                TxtFirstName.Focus();
                errorProvider1.SetError(TxtFirstName, "You Should Write First Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtFirstName, "");
            }
        }

        private void TxtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                e.Cancel = true;
                TxtLastName.Focus();
                errorProvider1.SetError(TxtLastName, "You Should Write Last Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtLastName, "");
            }
        }

        private void TxtNationalNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNationalNO.Text))
            {
                e.Cancel = true;
                TxtNationalNO.Focus();
                errorProvider1.SetError(TxtNationalNO, "You Should Write National Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtNationalNO, "");
            }
        }

        private void TxtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAddress.Text))
            {
                e.Cancel = true;
                TxtAddress.Focus();
                errorProvider1.SetError(TxtAddress, "You Should Write Address");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtAddress, "");
            }
        }

        private void maskedTextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBox2.Text == "")
            {
                e.Cancel = true;
                maskedTextBox2.Focus();
                errorProvider1.SetError(maskedTextBox2, "You Should Write Address");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox2, "");
            }
        }
    }
}

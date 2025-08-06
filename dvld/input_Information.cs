using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bussnisse_Layer;
using ContactsBusinessLayer;
namespace DVLD_Project
{
    public partial class input_Information : UserControl
    {
        public input_Information()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                pictureBox1.Image = Properties.Resources.Male_512;
        }

        private void input_Information_Load(object sender, EventArgs e)
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {

                comboBox1.Items.Add(row["CountryName"]);

            }
            if (pictureBox1.Image == Properties.Resources.Male_512)
            {
                radioButton1.Checked = true;
            }
            if (pictureBox1.Image == Properties.Resources.Female_512)
            {
                radioButton2.Checked = true;
            }
            if (radioButton1.Checked)
            {
                pictureBox1.Image = Properties.Resources.Male_512;
            }
            if (radioButton2.Checked)
            {
                pictureBox1.Image = Properties.Resources.Female_512;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Female_512;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backdvld.Persons person = new backdvld.Persons
            {
                FirstName = txtfirstname.Text,
                SecondName = txtsecondname.Text,
                ThirdName = txtthirdname.Text,
                LastName = txtlastname.Text,
                DateOfBirth = dateTimePicker1.Value,
                Gender = radioButton1.Checked ? (byte)1 : (radioButton2.Checked ? (byte)2 : (byte)0),
                Address = txtaddress.Text,
                phone = maskedTextBox2.Text,
                Email = txtemail.Text,
                NationalityCountryID = Convert.ToInt32(comboBox1.SelectedValue)
            };
            backdvld.AddPeople(person);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtfirstname.Text))
            {
                e.Cancel = true;
                txtfirstname.Focus();
                errorProvider1.SetError(txtfirstname, "You Should Write First Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtfirstname, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtlastname.Text))
            {
                e.Cancel = true;
                txtlastname.Focus();
                errorProvider1.SetError(txtlastname, "You Should Write Last Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtlastname, "");
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtaddress.Text))
            {
                e.Cancel = true;
                txtaddress.Focus();
                errorProvider1.SetError(txtaddress, "You Should Write Last Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtaddress, "");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

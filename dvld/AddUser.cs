using BussinesLayer;
using Country;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BussinesLayer.clsPerson;

namespace dvld
{
    public partial class AddUser : Form
    {

        public enum enMode {AddNew = 0, Update = 1}
        private enMode _Mode;
        private int _Userid;
        clsPerson.clsUser _user;
        clsPerson _person;
        public AddUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public AddUser(int userid)
        {
            InitializeComponent();
            _Userid = userid;
            _Mode = enMode.Update;
        }
        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _user = new clsUser();
                tabPage2.Enabled = false;
                ctrlPersonCartWithFilterControl1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                tabPage2.Enabled = true;
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            checkBox1.Checked = true;
        }
        private void _LoadData()
        {
            _user = clsUser.Find(_Userid);
            ctrlPersonCartWithFilterControl1.FilterEnabled = false;
            if (_user == null)
            {
                MessageBox.Show("No User with ID = " + _user, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lbluserID.Text = _user.UserID.ToString();
            txtUserName.Text = _user.userName;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            checkBox1.Checked = _user.IsActive;
            ctrlPersonCartWithFilterControl1.LoadPersonInfo(_user.PersonID);
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "You Should Write Username");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "You Should Write Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "You Should Write Confimin Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                txtConfirmPassword.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _user.PersonID = ctrlPersonCartWithFilterControl1.PersonID;
            _user.userName = txtUserName.Text.Trim();
            _user.Password = txtPassword.Text.Trim();
            _user.IsActive = checkBox1.Checked;
            if (_user.SaveForUsers())
            {
                lbluserID.Text = _user.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            }
            if (ctrlPersonCartWithFilterControl1.PersonID != -1)
            {
                if (clsUser.isUserExist(ctrlPersonCartWithFilterControl1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCartWithFilterControl1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tabPage2.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCartWithFilterControl1.FilterFocus();
            }
        }

        private void AddUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCartWithFilterControl1.FilterFocus();
        }
    }
}

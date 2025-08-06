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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace dvld
{
    public partial class ChangePassword : Form
    {
        //public enum enMode { AddNew = 0, Update = 1 }
        //private enMode _Mode;
        private int _Userid;
        clsPerson.clsUser _user;
        public ChangePassword(int UserID)
        {
            InitializeComponent();
            _Userid = UserID;
        }
        private void _LoadUser()
        {
            _user = clsPerson.clsUser.Find(_Userid);
            //clsPerson.clsUser.UserMode = clsPerson.clsUser.enModeUser.Update;
            lblIDUser.Text = _user.UserID.ToString();
            lblUserName.Text = _user.userName;
            lblStatus.Text = _user.IsActive == true ? "Active" : "Disabled";
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "You Should Write Current Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");
            }
            if (txtCurrentPassword.Text != _user.Password)
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "You Should Write Current Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "You Should Write  Password");
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
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "You Should Confermin Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _user.Password = txtConfirmPassword.Text;
            if (clsPerson.clsUser.UpdateUserPassword(_user.UserID, _user.Password))
                MessageBox.Show("Change Password Successfully :-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Change Password failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            _LoadUser();
        }

        private void txtCurrentPassword_Validated(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text != _user.Password)
            {
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "You Should Write Correct Current Password");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            if ( txtConfirmPassword.Text != txtPassword.Text)
            {
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "Password is Not Mismatched password");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }
    }
}

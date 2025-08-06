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
    public partial class UserCardControl : UserControl
    {
        private clsPerson.clsUser _user;
        private int _Userid;
        public UserCardControl()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID)
        {
            _Userid = UserID;
            _user = clsPerson.clsUser.Find(UserID);
            if (_user == null)
            {
                _RestPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        private void _FillPersonInfo()
        {
            ctrlPersonInformation1.LoadPersonInfo(_user.PersonID);
            lblID.Text = _user.UserID.ToString();
            lblusername.Text = _user.userName;
            lblisactive.Text = _user.IsActive ? "Active" : "Disable";
        }
        private void _RestPersonInfo()
        {
            lblID.Text = "[???]";
            lblusername.Text = "[???]";
            lblisactive.Text = "[???]";
        }
    }
}

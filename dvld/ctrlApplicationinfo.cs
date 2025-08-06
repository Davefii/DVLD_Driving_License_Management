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
using static System.Net.Mime.MediaTypeNames;

namespace dvld
{
    public partial class ctrlApplicationinfo : UserControl
    {
        clsApplication _application;
        private int _ApplicationID = -1;
        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public ctrlApplicationinfo()
        {
            InitializeComponent();
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _application = clsApplication.FindBaseApplication(ApplicationID);
            if (_application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }
        private void _FillApplicationInfo()
        {
            _ApplicationID = _application.ApplicationID;
            lblApplicationID.Text = _application.ApplicationID.ToString();
            lblStatus.Text = _application.StatusText;
            lblType.Text = _application.ApplicationTypeInfo.ApplicationTitleTypes;
            lblFees.Text = _application.PaidFees.ToString();
            lblApplicant.Text = _application.ApplicantFullName;
            lblDate.Text = _application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text =  _application.LastStatusDate.ToShortDateString();
            lblCreatedByUser.Text = _application.CreatedByUserInfo.userName;
        }
        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form4 = new Form4(_application.ApplicantPersonID);
            form4.ShowDialog();
        }
    }
}

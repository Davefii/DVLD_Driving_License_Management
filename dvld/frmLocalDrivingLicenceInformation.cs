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
    public partial class frmLocalDrivingLicenceInformation : Form
    {
        int _LicenceApplicationID = -1;

        public frmLocalDrivingLicenceInformation(int LicenceApplicationID)
        {
            InitializeComponent();
            _LicenceApplicationID = LicenceApplicationID;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingLicenceInformation_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenceInformation1.LoadApplicationInfoByLocalDrivingAppID(_LicenceApplicationID);
        }
    }
}

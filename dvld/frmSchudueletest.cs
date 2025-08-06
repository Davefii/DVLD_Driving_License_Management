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
    public partial class frmSchudueletest : Form
    {
        private int _LocalDrivingLicenceApplicationID = -1;
        private clsTestTypes.enTestType _TestTypes = clsTestTypes.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public frmSchudueletest(int LocalDrivingLicenceApplicationID, clsTestTypes.enTestType TestTypes, int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenceApplicationID = LocalDrivingLicenceApplicationID;
            _TestTypes = TestTypes;
            _AppointmentID = AppointmentID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSchudueletest_Load(object sender, EventArgs e)
        {
            ctrlSchuduleTest1.testTypeID = _TestTypes;
            ctrlSchuduleTest1.LoadInfo(_LocalDrivingLicenceApplicationID, _AppointmentID);
        }
    }
}

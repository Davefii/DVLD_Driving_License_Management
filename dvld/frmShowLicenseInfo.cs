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
    public partial class frmShowLicenseInfo : Form
    {
        private int _LicenceID;
        public frmShowLicenseInfo(int licenceID )
        {
            InitializeComponent();
            _LicenceID = licenceID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLoaclLicenceInformation1.LoadLicenceInfo(_LicenceID);
        }
    }
}

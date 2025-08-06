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
    public partial class frmInternationalLicence : Form
    {
        private int _InternationalLicense = -1;
        public frmInternationalLicence(int iLicenceID)
        {
            InitializeComponent();
            _InternationalLicense = iLicenceID;
        }

        private void frmInternationalLicence_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInformation1.LoadInfo(_InternationalLicense);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmLicenseHistory : Form
    {
        private int _PersonID = -1;
        public frmLicenseHistory()
        {
            InitializeComponent();
        }
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void ctrlPersonCartWithFilterControl1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID != -1)
            {
                ctrlDriverLicensesControl1.Clear();
            }
            ctrlDriverLicensesControl1.LoadInfoByPersonID(_PersonID);
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrlPersonCartWithFilterControl1.LoadPersonInfo(_PersonID);
                ctrlPersonCartWithFilterControl1.FilterEnabled = false;
                ctrlDriverLicensesControl1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlPersonCartWithFilterControl1.FilterEnabled = true;
                ctrlPersonCartWithFilterControl1.FilterFocus();
            }
        }
    }
}

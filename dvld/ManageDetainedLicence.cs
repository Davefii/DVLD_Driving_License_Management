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
    public partial class ManageDetainedLicence : Form
    {
        private DataTable _dtDetainedLicenses;
        public ManageDetainedLicence()
        {
            InitializeComponent();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicence detainLicence = new frmDetainLicence();
            detainLicence.ShowDialog();
            ManageDetainedLicence_Load(null, null);
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            ReleaseDetainLicence release = new ReleaseDetainLicence();
            release.ShowDialog();
            ManageDetainedLicence_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageDetainedLicence_Load(object sender, EventArgs e)
        {
            _dtDetainedLicenses = clsDatainLicence.GetAllDetainedLicenses();
            dataGridView1.DataSource = _dtDetainedLicenses;
            lblTotalRecords.Text = dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "D.ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "L.ID";
                dataGridView1.Columns[1].Width = 90;

                dataGridView1.Columns[2].HeaderText = "D.Date";
                dataGridView1.Columns[2].Width = 160;

                dataGridView1.Columns[3].HeaderText = "Is Released";
                dataGridView1.Columns[3].Width = 110;

                dataGridView1.Columns[4].HeaderText = "Fine Fees";
                dataGridView1.Columns[4].Width = 110;

                dataGridView1.Columns[5].HeaderText = "Release Date";
                dataGridView1.Columns[5].Width = 160;

                dataGridView1.Columns[6].HeaderText = "N.No.";
                dataGridView1.Columns[6].Width = 90;

                dataGridView1.Columns[7].HeaderText = "Full Name";
                dataGridView1.Columns[7].Width = 330;

                dataGridView1.Columns[8].HeaderText = "Rlease App.ID";
                dataGridView1.Columns[8].Width = 150;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    }

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = _dtDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblTotalRecords.Text = _dtDetainedLicenses.Rows.Count.ToString();
        }

        private void showPersonLicenceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            int personID = clsLicence.Find(LicenseID).DriverInfo.PersonID;
            frmLicenseHistory licenseHistory = new frmLicenseHistory(personID);
            licenseHistory.ShowDialog();
        }

        private void releaseDetatinLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            ReleaseDetainLicence releaseDetainLicence = new ReleaseDetainLicence(LicenseID);
            releaseDetainLicence.ShowDialog();
            ManageDetainedLicence_Load(null, null);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            int personID = clsLicence.Find(LicenseID).DriverInfo.PersonID;
            Form4 form4 = new Form4(personID);
            form4.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetatinLicenceToolStripMenuItem.Enabled = !(bool)dataGridView1.CurrentRow.Cells[3].Value;
        }
    }
}

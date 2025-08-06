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
    public partial class Update_Test_Types : Form
    {
        int _ID;
        clsTestTypes _TestTypes;
        public Update_Test_Types(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }
        private void _LoadContent()
        {
            _TestTypes = clsTestTypes.Find((clsTestTypes.enTestType)_ID);
            if (_TestTypes == null)
            {
                MessageBox.Show("Test Type is Null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                lblID.Text = _TestTypes.ID.ToString();
                txtTypes.Text = _TestTypes.TestTypeTitle;
                txtDescription.Text = _TestTypes.TestTypeDescription;
                txtfees.Text = _TestTypes.TestTypeFees.ToString();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtfees.Text, out int fee))
            {
                MessageBox.Show("Please enter a valid number for the fee.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _TestTypes.TestTypeTitle = txtTypes.Text;
            _TestTypes.TestTypeDescription = txtDescription.Text;
            _TestTypes.TestTypeFees = fee;
            if (_TestTypes.save())
            {
                MessageBox.Show("Test Type updated successfully",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();   // optionally close the form on success
            }
            else
            {
                MessageBox.Show("Failed to update Test Type",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Test_Types_Load(object sender, EventArgs e)
        {
            _LoadContent();
        }
    }
}

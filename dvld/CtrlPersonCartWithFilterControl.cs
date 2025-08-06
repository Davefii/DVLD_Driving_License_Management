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

    public partial class CtrlPersonCartWithFilterControl : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a Parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set { _ShowAddPerson = value; btnAddNewPerson.Enabled = _ShowAddPerson; }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set { _FilterEnabled = value; groupBox1.Enabled = _FilterEnabled; }
        }
        public CtrlPersonCartWithFilterControl()
        {
            InitializeComponent();
        }
        private int _PersonID = -1;
        public int PersonID { get { return ctrlPersonInformation1.PersonID; } }
        public clsPerson SelectedPerson { get { return ctrlPersonInformation1.SelectedPerson; } }
        public void LoadPersonInfo(int PersonID)
        {
            //_PersonID = PersonID;
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            _FindNow();
        }
        private void _FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonInformation1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "National No.":
                    ctrlPersonInformation1.LoadPersonInfo(txtFilterValue.Text);
                    break;
                default:
                    break;
            }
            if (OnPersonSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonInformation1.PersonID);
            }
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }
        private void CtrlPersonCartWithFilterControl_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddOrUpdatePeople addOrUpdatePeople = new AddOrUpdatePeople();
            addOrUpdatePeople.DataBack += DataBackEvent;
            addOrUpdatePeople.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonInformation1.LoadPersonInfo(PersonID);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
            // this will al low only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }
    }
}

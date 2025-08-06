using BussinesLayer;
using Country;
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
    public partial class Form4 : Form
    {
        public Form4(int id)
        {
            InitializeComponent();
            ctrlPersonInformation1.LoadPersonInfo(id);
        }
        public Form4(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonInformation1.LoadPersonInfo(NationalNo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

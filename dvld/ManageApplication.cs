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
    public partial class ManageApplication : Form
    {
        public ManageApplication()
        {
            InitializeComponent();
        }
        private void _ReferchContent()
        {
            dataGridView1.DataSource = clsApplicationTypes.GetAllAppliaction();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].HeaderText = "Application Type";
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].HeaderText = "Fee";
            dataGridView1.Columns[2].Width = 150;
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateApplicationType updateApplicationType = new UpdateApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            updateApplicationType.ShowDialog();
            _ReferchContent();
        }

        private void ManageApplication_Load(object sender, EventArgs e)
        {
            _ReferchContent();
        }
    }
}

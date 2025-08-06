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
    public partial class ManageTestTypes : Form
    {
        public ManageTestTypes()
        {
            InitializeComponent();
        }

        private void _RefershContent()
        {
            dataGridView1.DataSource = clsTestTypes.GetAllTestTypes();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Test Type";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Description Type";
            dataGridView1.Columns[2].Width = 550;
            dataGridView1.Columns[3].HeaderText = "Fee";
            dataGridView1.Columns[3].Width = 50;
        }

        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefershContent();
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Test_Types update_Test_Types = new Update_Test_Types((int)dataGridView1.CurrentRow.Cells[0].Value);
            update_Test_Types.ShowDialog();
            _RefershContent();
        }
    }
}

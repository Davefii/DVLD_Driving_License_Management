using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;
namespace dvld
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }
        private void _RefreshPersonList()
        {
            dataGridView1.DataSource = clsPerson.GetAllPeoples();
            lblCountR.Text = dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[1].HeaderText = "Nactional No";
                dataGridView1.Columns[1].Width = 110;
                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 110;
                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 110;
                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 110;
                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 110;
                dataGridView1.Columns[6].HeaderText = "Gendor";
                dataGridView1.Columns[6].Width = 110;
                dataGridView1.Columns[7].HeaderText = "DateofBirth";
                dataGridView1.Columns[7].Width = 110;
                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 110;
                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 110;
                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 110;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            _RefreshPersonList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrUpdatePeople frm3 = new AddOrUpdatePeople();
            frm3.ShowDialog();
            _RefreshPersonList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm3 = new AddOrUpdatePeople((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm3.ShowDialog();
            _RefreshPersonList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete this person?" + personId, "",MessageBoxButtons.OK,MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePeople(personId))
                {
                    MessageBox.Show("This person was deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete this person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _RefreshPersonList();
            }
        }

        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form4((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
                textBox1.Visible = true;
            else
                textBox1.Visible = false;
        }
    }
}

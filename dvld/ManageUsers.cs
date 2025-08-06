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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            ManageUsers_Load(null,null);
        }
        private void _ReferechUsersList()
        {
            dataGridView1.DataSource = clsPerson.clsUser.GetAllUsers();
            lblcount.Text = dataGridView1.Columns.Count.ToString();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].HeaderText = "FullName";
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Columns[3].HeaderText = "User Name";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].HeaderText = "is Active";
                dataGridView1.Columns[4].Width = 80;
            }
        }
        private void cellPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cell Phone Will Be Here");
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            _ReferechUsersList();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_SettingsCombobox();// fix combobox
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            addUser.ShowDialog();
            _ReferechUsersList();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Do You Want Delete This", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clsPerson.clsUser.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            }
            _ReferechUsersList();
        }

        private void showInfomrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmUserInfomation frm4 = new frmUserInfomation(personID);
            frm4.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
            _ReferechUsersList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Send Email Will Be Here");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

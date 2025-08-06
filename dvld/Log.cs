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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }
        private void _Authnation()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please insert User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please insert Password, if Forget Contact Your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            clsPerson.clsUser currentuser = clsPerson.clsUser.Login(textBox1.Text, textBox2.Text);
            if (currentuser == null)
            {
                if (MessageBox.Show("invaild UserName or Passwrod or Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                    return;
                }
            }
            if (!string.Equals(currentuser.userName, textBox1.Text, StringComparison.Ordinal))
            {
                MessageBox.Show("Invalid UserName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }
            if (!string.Equals(currentuser.Password, textBox2.Text, StringComparison.Ordinal))
            {
                MessageBox.Show("Invalid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
                return;
            }
            if (!currentuser.IsActive)
            {
                MessageBox.Show("This User is Not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
                return;
            }
            if (checkBox1.Checked)
            {
                clsGlobal.RememberUsernameAndPassword(textBox1.Text.Trim(), textBox2.Text.Trim());
            }
            else
            {
                clsGlobal.RememberUsernameAndPassword("", "");
            }
            clsGlobal.CurrentUser = currentuser;
            //this.Hide();
            Form1 mainForm = new Form1(this);
            mainForm.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _Authnation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                textBox1.Text = UserName;
                textBox2.Text = Password;
                checkBox1.Checked = true;
            }
            else
                checkBox1.Checked = false;
        }
    }
}

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
    public partial class frmUserInfomation : Form
    {
        clsPerson.clsUser _User;
        int _UserID;
        public frmUserInfomation(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfomation_Load(object sender, EventArgs e)
        {
            userCardControl1.LoadUserInfo(_UserID);
        }
    }
}

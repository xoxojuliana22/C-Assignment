using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            chefUpdateProfile chefUpdateProfile = new chefUpdateProfile();
            chefUpdateProfile.Show();
            this.Hide();

        }
    }
}

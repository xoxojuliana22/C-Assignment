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
    public partial class chefUpdateProfile : Form
    {

        public string chefId { get; set; }

        public chefUpdateProfile()
        {
            InitializeComponent();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            chefMain chefMain = new chefMain();
            chefMain.Show();
            this.Hide();
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            string newName = txtNameChef.Text;
            if (!string.IsNullOrEmpty(newName))
            {
                ChefProfile.UpdateChefName(chefId, newName);
                MessageBox.Show("Name updated successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a valid name.");
            }
        }

        private void btnChangeContact_Click(object sender, EventArgs e)
        {
            string newNumber = txtContactChef.Text;
            if (!string.IsNullOrEmpty(newNumber))
            {
                ChefProfile.UpdateChefNumber(chefId, newNumber);
                MessageBox.Show("Number updated successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void btnChangeEmail_Click(object sender, EventArgs e)
        {
            string newEmail = txtEmailChef.Text;
            if (!string.IsNullOrEmpty(newEmail))
            {
                ChefProfile.UpdateChefEmail(chefId, newEmail);
                MessageBox.Show("Email updated successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a valid email.");
            }
        }


        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            changePassword changePassword = new changePassword();
            changePassword.Show();
            this.Hide();

        }
    }
}

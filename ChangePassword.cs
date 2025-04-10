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
    public partial class frmChangePassword : Form
    {
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }

        public frmChangePassword(string loggedInCustomerID)
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword1 = txtNewPassword1.Text;
            string newPassword2 = txtNewPassword2.Text;

            Customer customer = new Customer();
            customer.CustomerID = loggedInCustomerID;

            string currentPassword = customer.GetCurrentPassword();

            if (oldPassword == currentPassword)
            {
                if (newPassword1 == newPassword2)
                {
                    customer.UpdatePassword(newPassword2);
                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    frmProfile profile = new frmProfile(loggedInCustomerID);
                    profile.loggedInCustomerID = loggedInCustomerID;
                    profile.TopLevel = false;
                    pnlCustomer.Controls.Clear();
                    pnlCustomer.Controls.Add(profile);
                    profile.BringToFront();
                    profile.Show();
                    profile.pnlCustomer = pnlCustomer;
                }
                else
                {
                    MessageBox.Show("New passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            txtOldPassword.Clear();
            txtNewPassword1.Clear();
            txtNewPassword2.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOldPassword.Text) ||
                !string.IsNullOrEmpty(txtNewPassword1.Text) ||
                !string.IsNullOrEmpty(txtNewPassword2.Text))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to leave? Changes will not be saved.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            frmProfile profile = new frmProfile(loggedInCustomerID);
            profile.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(profile);
            profile.BringToFront();
            profile.Show();
            profile.pnlCustomer = pnlCustomer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class frmUpdateProfile : Form
    {
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }

        public frmUpdateProfile(string customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;
        }

        private void UpdateProfile()
        {
            Customer customer = new Customer();
            customer.CustomerID = loggedInCustomerID;
            customer.UpdateProfile(txtUsername.Text, txtEmail.Text, txtContactNumber.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) ||
                !string.IsNullOrEmpty(txtEmail.Text) ||
                !string.IsNullOrEmpty(txtContactNumber.Text))
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

        private void btnDone_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerID = loggedInCustomerID;

            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();

            customer.UpdateProfile(
                username: string.IsNullOrWhiteSpace(username) ? null : username,
                email: string.IsNullOrWhiteSpace(email) ? null : email,
                contactNumber: string.IsNullOrWhiteSpace(contactNumber) ? null : contactNumber
            );

            MessageBox.Show("Profile Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

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
    public partial class frmProfile : Form
    {
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }

        public frmProfile(string customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;
            DisplayProfileData();
        }

        private void DisplayProfileData()
        {
            Customer customer = new Customer();
            customer.CustomerID = loggedInCustomerID;
            Customer profileData = customer.DisplayProfile();
            lblDCustomerID.Text = profileData.CustomerID;
            lblDUsername.Text = profileData.Username;
            lblDEmail.Text = profileData.Email;
            lblDContactNumber.Text = profileData.ContactNumber;
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            frmUpdateProfile updateProfile = new frmUpdateProfile(loggedInCustomerID);
            updateProfile.loggedInCustomerID = loggedInCustomerID;
            updateProfile.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(updateProfile);
            updateProfile.Dock = DockStyle.Fill;
            updateProfile.Show();
            updateProfile.pnlCustomer = pnlCustomer;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(loggedInCustomerID);
            changePassword.loggedInCustomerID = loggedInCustomerID;
            changePassword.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(changePassword);
            changePassword.Dock = DockStyle.Fill;
            changePassword.Show();
            changePassword.pnlCustomer = pnlCustomer;
        }
    }
}

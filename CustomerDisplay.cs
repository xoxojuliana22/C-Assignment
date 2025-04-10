using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IOOP_Assignment
{
    public partial class frmCustomerHome : Form
    {
        public string loggedInCustomerID { get; set; }

        public frmCustomerHome()
        {
            loggedInCustomerID = "ACU001";
            InitializeComponent();
            frmMenu menu = new frmMenu(loggedInCustomerID);
            menu.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(menu);
            menu.BringToFront();
            menu.Show();
            menu.pnlCustomer = pnlCustomer;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(loggedInCustomerID);
            menu.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(menu);
            menu.BringToFront();
            menu.Show();
            menu.pnlCustomer = pnlCustomer;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmOrders orders = new frmOrders(loggedInCustomerID);
            orders.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(orders);
            orders.BringToFront();
            orders.Show();
            orders.pnlCustomer = pnlCustomer;
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            frmReservations reservations = new frmReservations(loggedInCustomerID);
            reservations.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(reservations);
            reservations.BringToFront();
            reservations.Show();
            reservations.pnlCustomer = pnlCustomer;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile(loggedInCustomerID);
            profile.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(profile);
            profile.BringToFront();
            profile.Show();
            profile.pnlCustomer = pnlCustomer;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pnlCustomer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

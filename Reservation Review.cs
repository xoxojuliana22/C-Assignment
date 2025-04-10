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
    public partial class frmRReview : Form
    {
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }
        public ReservationCustomer.Reservation SelectedReservation { get; set; }

        public frmRReview(ReservationCustomer.Reservation reservation, string customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;
            SelectedReservation = reservation;
            lblDReservationNo.Text = SelectedReservation.ReservationID; // Display the reservation ID
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtRating.Text, out int rating))
            {
                if (rating <= 10)
                {
                    if (SelectedReservation != null)
                    {
                        Customer.Review review = new Customer.Review
                        {
                            ReservationID = SelectedReservation.ReservationID,
                            Rating = rating,
                            Description = txtFeedback.Text
                        };
                        Customer customer = new Customer();
                        customer.CustomerID = loggedInCustomerID;
                        customer.AddReview(review);
                        MessageBox.Show("Thanks for your feedback!", "Reviewed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmReservations reservations = new frmReservations(loggedInCustomerID);
                        reservations.TopLevel = false;
                        pnlCustomer.Controls.Clear();
                        pnlCustomer.Controls.Add(reservations);
                        reservations.BringToFront();
                        reservations.Show();
                        reservations.pnlCustomer = pnlCustomer;
                    }
                    else
                    {
                        MessageBox.Show("No reservation selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Rating", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid Rating. Enter Valid Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFeedback.Text))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to leave? This feedback will not be saved.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            frmReservations reservations = new frmReservations(loggedInCustomerID);
            reservations.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(reservations);
            reservations.BringToFront();
            reservations.Show();
            reservations.pnlCustomer = pnlCustomer;
        }
    }
}

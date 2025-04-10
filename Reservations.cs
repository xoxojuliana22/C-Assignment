using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IOOP_Assignment.Customer;

namespace IOOP_Assignment
{
    public partial class frmReservations : Form
    {
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }
        public ReservationCustomer.Reservation SelectedReservation { get; set; }

        public frmReservations(string customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;
            DisplayCurrentReservation();
            DisplayReservationHistory();
        }

        private void DisplayCurrentReservation()
        {
            ReservationCustomer reservationCustomer = new ReservationCustomer();
            List<ReservationCustomer.Reservation> upcomingReservations = reservationCustomer.GetCurrentReservations(loggedInCustomerID);

            if (upcomingReservations.Count > 0)
            {
                ReservationCustomer.Reservation nextReservation = upcomingReservations[0];
                lblUpcomingReservation.Text = $"Reservation ID: {nextReservation.ReservationID}\n" +
                                              $"Customer ID: {nextReservation.CustomerID}\n" +
                                              $"Hall ID: {nextReservation.HallID}\n" +
                                              $"Date & Time: {nextReservation.Date}\n" +
                                              $"Pax: {nextReservation.NumPeople}\n" +
                                              $"Category: {nextReservation.Category}";
            }
            else
            {
                lblUpcomingReservation.Text = "No Upcoming Reservations.\nPlease contact restaurant to make a reservation.";
            }
        }

        private void DisplayReservationHistory()
        {
            ReservationCustomer reservationCustomer = new ReservationCustomer();
            List<ReservationCustomer.Reservation> reservationHistory = reservationCustomer.GetReservationHistory(loggedInCustomerID);
            pnlHistory.Controls.Clear();
            if (reservationHistory.Count > 0)
            {
                pnlHistory.FlowDirection = FlowDirection.TopDown;
                pnlHistory.WrapContents = false;
                foreach (ReservationCustomer.Reservation res in reservationHistory)
                {
                    Panel reservationPanel = new Panel();
                    reservationPanel.BorderStyle = BorderStyle.FixedSingle;
                    reservationPanel.AutoSize = true;
                    reservationPanel.Margin = new Padding(10);

                    Label lblReservationDetails = new Label();
                    lblReservationDetails.Text = $"Reservation ID: {res.ReservationID}\n" +
                                                 $"Customer ID: {res.CustomerID}\n" +
                                                 $"Hall ID: {res.HallID}\n" +
                                                 $"Date & Time: {res.Date}\n" +
                                                 $"Pax: {res.NumPeople}\n" +
                                                 $"Category: {res.Category}";
                    lblReservationDetails.AutoSize = true;
                    lblReservationDetails.Font = new Font("Segoe Script", 13);

                    Button btnRReview = new Button();
                    btnRReview.Text = "Leave Review";
                    btnRReview.Size = new Size(120, 30);
                    btnRReview.Font = new Font("Segoe Print", 10);
                    btnRReview.Location = new Point(700, lblReservationDetails.Bottom + 50);
                    btnRReview.Tag = res;

                    btnRReview.Click += (sender, e) =>
                    {
                        Button clickedButton = (Button)sender;
                        ReservationCustomer.Reservation selectedReservation = (ReservationCustomer.Reservation)clickedButton.Tag;

                        frmRReview rreviewForm = new frmRReview(selectedReservation, loggedInCustomerID);
                        rreviewForm.pnlCustomer = pnlCustomer;
                        rreviewForm.TopLevel = false;
                        pnlCustomer.Controls.Clear();
                        pnlCustomer.Controls.Add(rreviewForm);
                        rreviewForm.BringToFront();
                        rreviewForm.Show();
                    };

                    if (reservationCustomer.HasReviewBeenMade(res.ReservationID))
                    {
                        btnRReview.Enabled = false;
                        btnRReview.Text = "Reviewed";
                    }

                    reservationPanel.Controls.Add(lblReservationDetails);
                    reservationPanel.Controls.Add(btnRReview);
                    pnlHistory.Controls.Add(reservationPanel);
                }
            }
            else
            {
                Label lblNoReservations = new Label();
                lblNoReservations.Text = "No Reservation History Found.";
                lblNoReservations.AutoSize = true;
                lblNoReservations.Font = new Font("Segoe Print", 11);
                pnlHistory.Controls.Add(lblNoReservations);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            ReservationCustomer reservationCustomer = new ReservationCustomer();
            List<ReservationCustomer.Reservation> upcomingReservations = reservationCustomer.GetCurrentReservations(loggedInCustomerID);

            if (upcomingReservations.Count > 0)
            {
                ReservationCustomer.Reservation nextReservation = upcomingReservations[0];
                reservationCustomer.MarkReservationDone(nextReservation.ReservationID);
                lblUpcomingReservation.Text = "No Upcoming Reservations. Please contact restaurant to make a reservation.";
                DisplayReservationHistory();
            }
        }

        private void btnRReview_Click(object sender, EventArgs e)
        {
            ReservationCustomer reservationCustomer = new ReservationCustomer();
            List<ReservationCustomer.Reservation> upcomingReservations = reservationCustomer.GetCurrentReservations(loggedInCustomerID);

            if (upcomingReservations.Count > 0)
            {
                ReservationCustomer.Reservation nextReservation = upcomingReservations[0];

                frmRReview rreviewForm = new frmRReview(nextReservation, loggedInCustomerID);
                rreviewForm.pnlCustomer = pnlCustomer;
                rreviewForm.TopLevel = false;
                pnlCustomer.Controls.Clear();
                pnlCustomer.Controls.Add(rreviewForm);
                rreviewForm.BringToFront();
                rreviewForm.Show();
            }
            else
            {
                MessageBox.Show("No Upcoming Reservations. Please contact restaurant to make a reservation.", "No Reservation Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
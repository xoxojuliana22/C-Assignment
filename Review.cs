using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class frmReview : Form
    {
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }
        private string orderID;

        public frmReview(string loggedInCustomerID, string orderID)
        {
            InitializeComponent();
            this.loggedInCustomerID = loggedInCustomerID;
            this.orderID = orderID;
            lblDOrderNo.Text = $"Order No: {orderID}";
        }

        private string GenerateReviewOrderID()
        {
            string reviewOrderID = "AOR001";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP 1 review_order_id FROM review_order ORDER BY review_order_id DESC", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string lastReviewOrderID = reader.GetString(0);
                    int numericPart = int.Parse(lastReviewOrderID.Substring(3)) + 1;
                    reviewOrderID = "AOR" + numericPart.ToString("D3");
                }
                reader.Close();
            }
            return reviewOrderID;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtRating.Text, out int rating))
            {
                if (rating >= 1 && rating <= 10)
                {
                    string reviewOrderID = GenerateReviewOrderID();

                    // Save the review to the database
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO review_order (review_order_Id, orderId, ro_rating, ro_description) VALUES (@reviewOrderID, @orderID, @rating, @description)", connection);
                        command.Parameters.AddWithValue("@reviewOrderID", reviewOrderID);
                        command.Parameters.AddWithValue("@orderID", orderID);
                        command.Parameters.AddWithValue("@rating", rating);
                        command.Parameters.AddWithValue("@description", txtFeedback.Text);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thanks for your feedback!", "Reviewed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NavigateToOrders();
                }
                else
                {
                    MessageBox.Show("Invalid Rating. Please enter a number between 1 and 10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid Rating. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NavigateToOrders()
        {
            frmOrders orders = new frmOrders(loggedInCustomerID);
            orders.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(orders);
            orders.BringToFront();
            orders.Show();
            orders.pnlCustomer = pnlCustomer;
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

            frmOrders orders = new frmOrders(loggedInCustomerID);
            orders.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(orders);
            orders.BringToFront();
            orders.Show();
            orders.pnlCustomer = pnlCustomer;
        }
    }
}

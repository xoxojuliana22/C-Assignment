using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class frmOrders : Form
    {
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }
        private DataGridView dgvCurrentOrders;
        private Button btnReview;

        public frmOrders(string customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;

            // Initialize the DataGridView for current orders
            dgvCurrentOrders = new DataGridView
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                Font = new Font("Segoe Print", 9),
                BackgroundColor = Color.White
            };

            dgvCurrentOrders.Columns[0].Name = "No.";
            dgvCurrentOrders.Columns[1].Name = "Order ID";
            dgvCurrentOrders.Columns[2].Name = "Menu Item";
            dgvCurrentOrders.Columns[3].Name = "Quantity";
            dgvCurrentOrders.Columns[4].Name = "Order Status";
            dgvCurrentOrders.Columns[0].Width = 50;
            dgvCurrentOrders.Columns[1].Width = 100;
            dgvCurrentOrders.Columns[2].Width = 400;
            dgvCurrentOrders.Columns[3].Width = 100;
            dgvCurrentOrders.Columns[4].Width = 100;

            pnlCurrentOrder.Controls.Add(dgvCurrentOrders);

            // Initialize the btnReview control
            btnReview = new Button
            {
                Text = "Review",
                Font = new Font("Segoe Print", 10)
            };

            // Wire up the event handler
            btnReview.Click += btnReview_Click;

            DisplayCurrentOrders();
            DisplayOrderHistory();
        }

        private void DisplayCurrentOrders()
        {
            pnlCurrentOrder.Controls.Clear();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"
        SELECT o.orderId, o.orderdatetime, o.totalprice, od.order_detail_Id, m.m_name, od.quantity
        FROM [order] o
        JOIN order_details od ON o.orderId = od.orderId
        JOIN menu m ON od.menuId = m.menuId
        WHERE o.customerId = @customerID AND o.order_status = 'Pending'
        ORDER BY o.orderdatetime DESC", connection);
                command.Parameters.AddWithValue("@customerID", loggedInCustomerID);
                SqlDataReader reader = command.ExecuteReader();

                string currentOrderID = "";
                Panel orderPanel = null;
                Label lblOrderInfo = null;

                while (reader.Read())
                {
                    string orderID = reader["orderId"].ToString();
                    if (orderID != currentOrderID)
                    {
                        if (orderPanel != null)
                        {
                            pnlCurrentOrder.Controls.Add(orderPanel);
                        }

                        currentOrderID = orderID;
                        orderPanel = new Panel
                        {
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            BorderStyle = BorderStyle.Fixed3D,
                            Margin = new Padding(5)
                        };

                        lblOrderInfo = new Label
                        {
                            Font = new Font("Segoe Print", 10),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblOrderInfo);

                        // Add Done button for each order panel
                        Button btnDone = new Button
                        {
                            Text = "Done",
                            Font = new Font("Segoe Print", 10),
                            Location = new Point(700, lblOrderInfo.Bottom + 40),
                            AutoSize = true
                        };
                        btnDone.Click += (sender, e) => MarkOrderAsCompleted(orderID);
                        orderPanel.Controls.Add(btnDone);

                        // Calculate totalPrice for the current order
                        decimal totalPrice = reader.GetDecimal(reader.GetOrdinal("totalprice"));

                        lblOrderInfo.Text += $"Order ID: {orderID}\n" +
                                             $"Date: {reader.GetDateTime(reader.GetOrdinal("orderdatetime"))}\n" +
                                             "Menu Items:\n";

                        int itemIndex = 1;
                        do
                        {
                            lblOrderInfo.Text += $"{itemIndex++}. {reader["m_name"]} (Qty: {reader["quantity"]})\n";
                        } while (reader.Read() && reader["orderId"].ToString() == orderID);

                        // Display total price for the current order
                        lblOrderInfo.Text += $"Total Price: RM {totalPrice:0.00}\n\n";
                    }
                }

                if (orderPanel != null)
                {
                    pnlCurrentOrder.Controls.Add(orderPanel);
                }

                reader.Close(); // Close the reader after reading all data
            }
        }


        private void MarkOrderAsCompleted(string orderID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [order] SET order_status = 'Completed' WHERE orderId = @orderID", connection);
                command.Parameters.AddWithValue("@orderID", orderID);
                command.ExecuteNonQuery();
            }

            DisplayCurrentOrders();
            DisplayOrderHistory();
        }

        private void DisplayOrderHistory()
        {
            pnlOrderHistory.Controls.Clear();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"
            SELECT o.orderId, o.orderdatetime, o.totalprice, od.order_detail_Id, m.m_name, od.quantity
            FROM [order] o
            JOIN order_details od ON o.orderId = od.orderId
            JOIN menu m ON od.menuId = m.menuId
            WHERE o.customerId = @customerID AND o.order_status = 'Completed'
            ORDER BY o.orderdatetime DESC", connection);
                command.Parameters.AddWithValue("@customerID", loggedInCustomerID);
                SqlDataReader reader = command.ExecuteReader();

                string currentOrderID = "";
                Panel orderPanel = null;
                Label lblOrderInfo = null;

                while (reader.Read())
                {
                    string orderID = reader["orderId"].ToString();
                    if (orderID != currentOrderID)
                    {
                        if (orderPanel != null)
                        {
                            pnlOrderHistory.Controls.Add(orderPanel);
                        }

                        currentOrderID = orderID;
                        orderPanel = new Panel
                        {
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            BorderStyle = BorderStyle.Fixed3D,
                            Margin = new Padding(5)
                        };

                        lblOrderInfo = new Label
                        {
                            Font = new Font("Segoe Print", 10),
                            AutoSize = true
                        };
                        orderPanel.Controls.Add(lblOrderInfo);

                        // Check if the order has been reviewed
                        bool reviewed = OrderHasBeenReviewed(orderID);
                        string reviewButtonText = reviewed ? "Reviewed" : "Review";

                        // Add the btnReview control to the orderPanel
                        Button btnReview = new Button
                        {
                            Text = reviewButtonText,
                            Font = new Font("Segoe Print", 10),
                            Location = new Point(700, lblOrderInfo.Bottom + 40),
                            AutoSize = true,
                            Enabled = !reviewed // Disable the button if the order has been reviewed
                        };
                        btnReview.Click += btnReview_Click;
                        btnReview.Tag = orderID; // Assign the orderID to the Tag property of btnReview
                        orderPanel.Controls.Add(btnReview);
                    }

                    lblOrderInfo.Text += $"Order ID: {orderID}\n" +
                                         $"Date: {reader.GetDateTime(reader.GetOrdinal("orderdatetime"))}\n" +
                                         "Menu Items:\n";

                    int itemIndex = 1;
                    decimal totalPrice = 0;
                    do
                    {
                        lblOrderInfo.Text += $"{itemIndex++}. {reader["m_name"]} (Qty: {reader["quantity"]})\n";
                        totalPrice = reader.GetDecimal(reader.GetOrdinal("totalprice"));
                    } while (reader.Read() && reader["orderId"].ToString() == orderID);

                    lblOrderInfo.Text += $"Total Price: RM {totalPrice:0.00}\n\n";

                    if (orderPanel != null)
                    {
                        pnlOrderHistory.Controls.Add(orderPanel);
                    }
                }

                reader.Close();
            }
        }

        // Method to check if an order has been reviewed
        private bool OrderHasBeenReviewed(string orderID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM review_order WHERE orderID = @orderID", connection);
                command.Parameters.AddWithValue("@orderID", orderID);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            string orderID = (sender as Button).Tag.ToString();
            frmReview review = new frmReview(loggedInCustomerID, orderID);
            review.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(review);
            review.BringToFront();
            review.Show();
            review.pnlCustomer = pnlCustomer;
        }
    }
}
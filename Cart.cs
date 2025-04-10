using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class frmCart : Form
    {
        private List<Order> orders = new List<Order>();
        private DataGridView dgvOrders;
        private decimal totalPrice = 0;
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }
        private Dictionary<string, int> orderItems;

        public frmCart(Dictionary<string, int> orderItems, string customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;
            this.orderItems = orderItems;
            // Initialize the DataGridView
            dgvOrders = new DataGridView
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                Font = new Font("Segoe Print", 9),
                BackgroundColor = Color.White,
                ReadOnly = true
            };
            dgvOrders.Columns[0].Name = "No.";
            dgvOrders.Columns[1].Name = "Menu ID";
            dgvOrders.Columns[2].Name = "Menu Item";
            dgvOrders.Columns[3].Name = "Price";
            dgvOrders.Columns[4].Name = "Quantity";
            dgvOrders.Columns[0].Width = 50;
            dgvOrders.Columns[1].Width = 100;
            dgvOrders.Columns[2].Width = 400;
            dgvOrders.Columns[3].Width = 100;
            dgvOrders.Columns[4].Width = 100;
            pnlCart.Controls.Add(dgvOrders);
            orders = Order.PopulateOrdersList(orderItems);
            dgvOrders.Rows.Clear();
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            dgvOrders.Rows.Clear();
            totalPrice = 0;
            int rowIndex = 0;
            foreach (Order order in orders)
            {
                dgvOrders.Rows.Add();
                dgvOrders.Rows[rowIndex].Cells[0].Value = rowIndex + 1;
                dgvOrders.Rows[rowIndex].Cells[1].Value = order.MenuId;
                dgvOrders.Rows[rowIndex].Cells[2].Value = order.Name;
                dgvOrders.Rows[rowIndex].Cells[3].Value = order.Price.ToString("RM 0.00");
                dgvOrders.Rows[rowIndex].Cells[4].Value = order.Quantity;
                totalPrice += order.Price * order.Quantity;
                rowIndex++;
            }
            lblTotal.Text = $"Total: RM {totalPrice:0.00}";
        }

        private void SaveOrder()
        {
            string orderID = Order.GenerateOrderID();
            Order.SaveOrderToDatabase(orderID, totalPrice, loggedInCustomerID);
            Order.SaveOrderDetailsToDatabase(orderID, orderItems);
            MessageBox.Show("Payment Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Clear orderItems dictionary after successful payment
            orderItems.Clear();
            // After saving order, navigate to menu
            NavigateToMenu();
        }

        private void NavigateToMenu()
        {
            frmMenu menu = new frmMenu(loggedInCustomerID);
            menu.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(menu);
            menu.BringToFront();
            menu.Show();
            menu.pnlCustomer = pnlCustomer;
        }

        private void btnPay1_Click(object sender, EventArgs e) { SaveOrder(); }
        private void btnPay2_Click(object sender, EventArgs e) { SaveOrder(); }
        private void btnPay3_Click(object sender, EventArgs e) { SaveOrder(); }
    }
}
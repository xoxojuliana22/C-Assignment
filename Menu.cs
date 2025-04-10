using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class frmMenu : Form
    {
        private MenuDisplay menuDisplay;
        public Panel pnlCustomer { get; set; }
        public string loggedInCustomerID { get; set; }

        // Change orderItems to a dictionary to store menuID and quantity
        private Dictionary<string, int> orderItems = new Dictionary<string, int>();


        // Declare GroupBoxes as class-level variables
        private GroupBox grpMainDishes;
        private GroupBox grpDessert;
        private GroupBox grpBeverages;

        public frmMenu(string customerID)
        {
            InitializeComponent();
            loggedInCustomerID = customerID;

            // Create and configure the category group boxes
            grpMainDishes = new GroupBox
            {
                Text = "Main Dishes",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                MinimumSize = new Size(965, 0),
                MaximumSize = new Size(965, 0),
                Font = new Font("Segoe Print", 12),
                Visible = true // Initially visible
            };

            grpDessert = new GroupBox
            {
                Text = "Dessert",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                MinimumSize = new Size(965, 0),
                MaximumSize = new Size(965, 0),
                Font = new Font("Segoe Print", 12),
                Visible = true // Initially visible
            };

            grpBeverages = new GroupBox
            {
                Text = "Beverages",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                MinimumSize = new Size(965, 0),
                MaximumSize = new Size(965, 0),
                Font = new Font("Segoe Print", 12),
                Visible = true // Initially visible
            };

            // Add the category group boxes to the existing flowMenu
            flowMenu.Controls.Add(grpMainDishes);
            flowMenu.Controls.Add(grpDessert);
            flowMenu.Controls.Add(grpBeverages);

            // Initialize the MenuDisplay class with the group boxes
            menuDisplay = new MenuDisplay(grpMainDishes, grpDessert, grpBeverages, PlusButton_Click, MinusButton_Click);

            menuDisplay.DisplayMenuItems(PlusButton_Click, MinusButton_Click);

            // Attach the TextChanged event handler to the txtSearch TextBox
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        // Event handler for txtSearch TextBox's TextChanged event
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        // Method to perform the search
        private void PerformSearch()
        {
            string searchTerm = txtSearch.Text.Trim().ToLower(); // Get the search term and convert it to lowercase

            // If the search term is empty, show all panels
            if (string.IsNullOrEmpty(searchTerm))
            {
                ShowAllPanels();
                return;
            }

            // Iterate through the controls of the form
            foreach (Control control in flowMenu.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (Control groupBoxControl in groupBox.Controls)
                    {
                        if (groupBoxControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control panelControl in flowLayoutPanel.Controls)
                            {
                                if (panelControl is Panel panel)
                                {
                                    // Find the Label control inside the Panel
                                    Label lblInfo = panel.Controls.OfType<Label>().FirstOrDefault();

                                    // Check if the label's text contains the search term or if panel.Tag is not null and contains the search term
                                    if (lblInfo != null && (lblInfo.Text.ToLower().Contains(searchTerm) || (panel.Tag != null && panel.Tag.ToString().ToLower().Contains(searchTerm))))
                                    {
                                        // Show the panel if the search term is found
                                        panel.Visible = true;
                                    }
                                    else
                                    {
                                        // Hide the panel if the search term is not found
                                        panel.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Method to show all panels
        private void ShowAllPanels()
        {
            foreach (Control control in flowMenu.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (Control groupBoxControl in groupBox.Controls)
                    {
                        if (groupBoxControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control panelControl in flowLayoutPanel.Controls)
                            {
                                if (panelControl is Panel panel)
                                {
                                    panel.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            Button plusButton = sender as Button;
            var tag = plusButton.Tag as Tuple<string, Label>;
            string menuItemID = tag.Item1;
            Label lblQuantity = tag.Item2;

            if (orderItems.ContainsKey(menuItemID))
            {
                orderItems[menuItemID]++;
            }
            else
            {
                orderItems[menuItemID] = 1;
            }

            lblQuantity.Text = orderItems[menuItemID].ToString();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            Button minusButton = sender as Button;
            var tag = minusButton.Tag as Tuple<string, Label>;
            string menuItemID = tag.Item1;
            Label lblQuantity = tag.Item2;

            if (orderItems.ContainsKey(menuItemID) && orderItems[menuItemID] > 0)
            {
                orderItems[menuItemID]--;
                lblQuantity.Text = orderItems[menuItemID].ToString();

                if (orderItems[menuItemID] == 0)
                {
                    orderItems.Remove(menuItemID);
                }
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            frmCart cart = new frmCart(orderItems, loggedInCustomerID);
            cart.TopLevel = false;
            pnlCustomer.Controls.Clear();
            pnlCustomer.Controls.Add(cart);
            cart.Dock = DockStyle.Fill;
            cart.Show();
            cart.pnlCustomer = pnlCustomer;
        }

        private void btnMainDishes_Click(object sender, EventArgs e)
        {
            grpMainDishes.Visible = true;
            grpDessert.Visible = false;
            grpBeverages.Visible = false;
            flowMenu.Controls.Clear();
            flowMenu.Controls.Add(grpMainDishes);
        }

        private void btnDessert_Click(object sender, EventArgs e)
        {
            grpMainDishes.Visible = false;
            grpDessert.Visible = true;
            grpBeverages.Visible = false;
            flowMenu.Controls.Clear();
            flowMenu.Controls.Add(grpDessert);
        }

        private void btnBeverages_Click(object sender, EventArgs e)
        {
            grpMainDishes.Visible = false;
            grpDessert.Visible = false;
            grpBeverages.Visible = true;
            flowMenu.Controls.Clear();
            flowMenu.Controls.Add(grpBeverages);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            grpMainDishes.Visible = true;
            grpDessert.Visible = true;
            grpBeverages.Visible = true;
            flowMenu.Controls.Clear();
            flowMenu.Controls.Add(grpMainDishes);
            flowMenu.Controls.Add(grpDessert);
            flowMenu.Controls.Add(grpBeverages);
        }
    }
}

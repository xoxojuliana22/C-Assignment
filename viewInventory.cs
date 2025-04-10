using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace IOOP_Assignment
{
    public partial class viewInventory : Form
    {
        public viewInventory()
        {
            InitializeComponent();
        }

        private void LoadInventoryData()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "SELECT * FROM Inventory";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvInventory.DataSource = dataTable;
            }
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            chefMain chefMain = new chefMain();
            chefMain.Show();
            this.Hide();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            string item_id = txtIngID.Text;
            string itemName = txtAddName.Text;
            double itemQuantityKg;

            // Validate and convert the quantity input
            if (double.TryParse(txtNewWeight.Text, out itemQuantityKg))
            {
                // Call the AddItem method from the Inventory class
                Inventory.AddItem(item_id, itemName, itemQuantityKg);

                // Optionally, display a success message
                MessageBox.Show("Item added successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity!");
            }

        }


        //????? WHAT IS THIS FOR EXACTLY????????????
        private void viewInventory_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
        }


                                                                                                                                                                                                                                        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchIngredient.Text;
            List<Inventory> searchResults = Inventory.SearchItems(searchTerm);

            // Convert searchResults to a DataTable and bind to DataGridView
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("itemId");
            dataTable.Columns.Add("item_name");
            dataTable.Columns.Add("item_quantity_kg");

            foreach (var item in searchResults)
            {
                dataTable.Rows.Add(item.itemId, item.item_name, item.item_quantity_kg);
            }

            dgvInventory.DataSource = dataTable;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            string itemId = txtIngID.Text;

            Inventory.DeleteItem(itemId);
            LoadInventoryData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvInventory.SelectedRows.Count > 0)
            {
                // Get the ID of the selected item
                string item_Id = Convert.ToString(dgvInventory.SelectedRows[0].Cells["itemId"].Value);

                // Get the updated item name and weight from your form's controls
                string updatedItemName = txtEditName.Text;


                // Call the UpdateItem method with the selected item's ID and updated values
                Inventory.UpdateItemName(item_Id, updatedItemName);


            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }
    }


}

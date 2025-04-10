using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace IOOP_Assignment
{
    internal class Inventory
    {

        // Member fields of Inventory
        public string itemId { get; set; }
        public string item_name { get; set; }

        public double item_quantity_kg { get; set; }

        public Inventory(string item_id, string itemName, double weight)
        {
            itemId = item_id;
            item_name = itemName;
            item_quantity_kg = weight;
        }

        // Method to add a new item to the inventory
        public static void AddItem(string item_id, string itemName, double weight)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "INSERT INTO inventory (itemId, item_name, item_quantity_kg) VALUES (@itemId, @item_name, @item_quantity_kg)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemId", item_id);
                command.Parameters.AddWithValue("@item_name", itemName);
                command.Parameters.AddWithValue("@item_quantity_kg", weight);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateItemName(string item_id, string itemName)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "UPDATE Inventory SET item_name = @ItemName WHERE itemId = @ItemId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", item_id);
                command.Parameters.AddWithValue("@ItemName", itemName);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public static void Restock(double weight)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "UPDATE Inventory SET item_quantity_kg = @item_quantity_kg WHERE itemId = @ItemId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@item_quantity_kg", weight);
            }
        }


        // Method to delete an item from the inventory
        public static void DeleteItem(string itemId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "DELETE FROM Inventory WHERE itemid = @ItemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemID", itemId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static List<Inventory> SearchItems(string searchTerm)
        {
            List<Inventory> searchResults = new List<Inventory>();


            // this ensures the connection is closed properly
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                //Query that matches search to records
                string query = "SELECT * FROM Inventory WHERE item_name OR itemId LIKE @SearchTerm";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // read data from the database and fll the searchResults list accordingly
                    while (reader.Read())
                    {
                        Inventory item = new Inventory(
                            reader["itemId"].ToString(),
                            reader["item_name"].ToString(),
                            Convert.ToDouble(reader["item_quantity_kg"])
                        );
                        searchResults.Add(item);
                    }
                }
            }

            return searchResults;
        }

    }

    internal class ChefProfile
    {
        // Method to update chef's name

        public string chefId { get; set; }
        public static void UpdateChefName(string chefId, string newName)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "UPDATE Chef SET ch_name = @ChefName WHERE ch_id = @ChefId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ChefName", newName);
                command.Parameters.AddWithValue("@ChefId", chefId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update chef's email
        public static void UpdateChefEmail(string chefId, string newEmail)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "UPDATE Chef SET ch_email = @ChefEmail WHERE ch_id = @ChefId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ChefEmail", newEmail);
                command.Parameters.AddWithValue("@ChefId", chefId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update chef's number
        public static void UpdateChefNumber(string chefId, string newNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ConnectionString))
            {
                string query = "UPDATE Chef SET chef_number = @ChefNumber WHERE ch_id = @ChefId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ChefNumber", newNumber);
                command.Parameters.AddWithValue("@ChefId", chefId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}

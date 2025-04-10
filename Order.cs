using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public class Order
    {
        public string MenuId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  // Changed from float to decimal
        public int Quantity { get; set; }

        public Order(string menuId, string name, decimal price, int quantity)
        {
            MenuId = menuId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public static List<Order> PopulateOrdersList(Dictionary<string, int> orderItems)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                foreach (var kvp in orderItems)
                {
                    string menuItemID = kvp.Key;
                    int quantity = kvp.Value;
                    SqlCommand command = new SqlCommand("SELECT m_name, m_price, menuId FROM menu WHERE menuId = @menuID", connection);
                    command.Parameters.AddWithValue("@menuID", menuItemID);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("m_name"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("m_price"));  // Changed from GetFloat to GetDecimal
                        Order order = new Order(menuItemID, name, price, quantity);
                        orders.Add(order);
                    }
                    reader.Close();
                }
            }
            return orders;
        }

        public static string GenerateOrderID()
        {
            string orderID = "ARO001";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP 1 orderId FROM [order] ORDER BY orderId DESC", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string lastOrderID = reader.GetString(0);
                    int numericPart = int.Parse(lastOrderID.Substring(3)) + 1;
                    orderID = "ARO" + numericPart.ToString("D3");
                }
                reader.Close();
            }
            return orderID;
        }

        public static void SaveOrderDetailsToDatabase(string orderID, Dictionary<string, int> orderItems)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                foreach (var kvp in orderItems)
                {
                    string menuItemID = kvp.Key;
                    int quantity = kvp.Value;

                    SqlCommand command = new SqlCommand("INSERT INTO order_details (orderId, menuId, quantity) VALUES (@orderID, @menuID, @quantity)", connection);
                    command.Parameters.AddWithValue("@orderID", orderID);
                    command.Parameters.AddWithValue("@menuID", menuItemID);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void SaveOrderToDatabase(string orderID, decimal totalPrice, string customerID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [order] (orderID, customerID, totalprice, order_status) VALUES (@orderID, @customerID, @totalprice, 'Pending')", connection);
                command.Parameters.AddWithValue("@orderID", orderID);
                command.Parameters.AddWithValue("@customerID", customerID);
                command.Parameters.AddWithValue("@totalprice", totalPrice);
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateOrderStatus(string orderID, string status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [order] SET order_status = @status WHERE orderId = @orderID", connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@orderID", orderID);
                command.ExecuteNonQuery();
            }
        }

        public static List<Tuple<string, DateTime, decimal>> GetOrderHistory(string customerID)
        {
            List<Tuple<string, DateTime, decimal>> orderHistory = new List<Tuple<string, DateTime, decimal>>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT orderID, orderDateTime, totalprice FROM [order] WHERE customerID = @customerID ORDER BY orderDateTime DESC", connection);
                command.Parameters.AddWithValue("@customerID", customerID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string orderID = reader.GetString(reader.GetOrdinal("orderID"));
                    DateTime orderDateTime = reader.GetDateTime(reader.GetOrdinal("orderDateTime"));
                    decimal totalPrice = reader.GetDecimal(reader.GetOrdinal("totalprice"));
                    orderHistory.Add(new Tuple<string, DateTime, decimal>(orderID, orderDateTime, totalPrice));
                }
                reader.Close();
            }
            return orderHistory;
        }
    }
}
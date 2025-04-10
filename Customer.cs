using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace IOOP_Assignment
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        private string connectionString = ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString;

        public Customer GetLoggedInCustomerID()
        {
            Customer customer = new Customer();
            string connectionString = ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT customerid, c_name, c_email, c_num FROM Customer WHERE customerid = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", "ACU001");
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    customer.CustomerID = reader["customerid"].ToString();
                    customer.Username = reader["c_name"].ToString();
                    customer.Email = reader["c_email"].ToString();
                    customer.ContactNumber = reader["c_num"].ToString();
                }

                reader.Close();
            }

            return customer;
        }

        public Customer DisplayProfile()
        {
            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT customerid, c_name, c_email, c_num FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", this.CustomerID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    customer.CustomerID = reader["customerid"].ToString();
                    customer.Username = reader["c_name"].ToString();
                    customer.Email = reader["c_email"].ToString();
                    customer.ContactNumber = reader["c_num"].ToString();
                }
                reader.Close();
            }

            return customer;
        }

        public void UpdateProfile(string username = null, string email = null, string contactNumber = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> fieldsToUpdate = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(username))
                {
                    fieldsToUpdate.Add("c_name = @Username");
                    parameters.Add(new SqlParameter("@Username", username));
                }

                if (!string.IsNullOrWhiteSpace(email))
                {
                    fieldsToUpdate.Add("c_email = @Email");
                    parameters.Add(new SqlParameter("@Email", email));
                }

                if (!string.IsNullOrWhiteSpace(contactNumber))
                {
                    fieldsToUpdate.Add("c_num = @ContactNumber");
                    parameters.Add(new SqlParameter("@ContactNumber", contactNumber));
                }

                if (fieldsToUpdate.Count == 0)
                    return; // No fields to update, return without executing query

                string queryFields = string.Join(", ", fieldsToUpdate);
                string query = $"UPDATE Customer SET {queryFields} WHERE CustomerID = @CustomerID";
                parameters.Add(new SqlParameter("@CustomerID", this.CustomerID));

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddRange(parameters.ToArray());

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string GetCurrentPassword()
        {
            string currentPassword = string.Empty;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT c_password FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", this.CustomerID);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    currentPassword = result.ToString();
                }
            }
            return currentPassword;
        }

        public void UpdatePassword(string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customer SET c_password = @NewPassword WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", this.CustomerID);
                command.Parameters.AddWithValue("@NewPassword", newPassword);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public class Review
        {
            public string ReviewID { get; set; }
            public string ReservationID { get; set; }
            public int Rating { get; set; }
            public string Description { get; set; }
        }

        public void AddReview(Review review)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get the next available ReviewID
                string nextReviewID = GetNextReviewID(connection);

                // Insert the review record
                string query = "INSERT INTO review_reservation (review_reservation_id, reservationId, rr_rating, rr_description) " +
                               "VALUES (@ReviewID, @ReservationID, @Rating, @Description)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReviewID", nextReviewID);
                command.Parameters.AddWithValue("@ReservationID", review.ReservationID);
                command.Parameters.AddWithValue("@Rating", review.Rating);
                command.Parameters.AddWithValue("@Description", review.Description);
                command.ExecuteNonQuery();
            }
        }

        private string GetNextReviewID(SqlConnection connection)
        {
            string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(review_reservation_id, 3, LEN(review_reservation_id)) AS INT)), 0) + 1 FROM review_reservation";
            SqlCommand command = new SqlCommand(query, connection);
            int nextID = (int)command.ExecuteScalar();
            return $"RR{nextID:D3}";
        }
    }
}

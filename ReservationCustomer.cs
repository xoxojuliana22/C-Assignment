using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace IOOP_Assignment
{
    public class ReservationCustomer
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString;

        public class Reservation
        {
            public string ReservationID { get; set; }
            public string CustomerID { get; set; }
            public string HallID { get; set; }
            public DateTime Date { get; set; }
            public int NumPeople { get; set; }
            public string Category { get; set; }
            public bool Status { get; set; }
        }

        public List<Reservation> GetCurrentReservations(string customerID)
        {
            List<Reservation> upcomingReservations = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reservation WHERE CustomerID = @CustomerID AND r_status = 0";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        ReservationID = reader["reservationid"].ToString(),
                        CustomerID = reader["customerid"].ToString(),
                        HallID = reader["hallid"].ToString(),
                        Date = (DateTime)reader["r_date"],
                        NumPeople = (int)reader["r_numpeople"],
                        Category = reader["r_category"].ToString(),
                        Status = (bool)reader["r_status"]
                    };

                    upcomingReservations.Add(reservation);
                }

                reader.Close();
            }

            return upcomingReservations;
        }

        public List<Reservation> GetReservationHistory(string customerID)
        {
            List<Reservation> reservationHistory = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT * FROM Reservation 
                WHERE CustomerID = @CustomerID AND r_status = 1 
                ORDER BY r_date DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        ReservationID = reader["reservationid"].ToString(),
                        CustomerID = reader["customerid"].ToString(),
                        HallID = reader["hallid"].ToString(),
                        Date = (DateTime)reader["r_date"],
                        NumPeople = (int)reader["r_numpeople"],
                        Category = reader["r_category"].ToString(),
                        Status = (bool)reader["r_status"]
                    };

                    reservationHistory.Add(reservation);
                }

                reader.Close();
            }

            return reservationHistory;
        }

        public bool HasReviewBeenMade(string reservationID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM review_reservation WHERE reservationId = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", reservationID);
                connection.Open();
                int reviewCount = (int)command.ExecuteScalar();
                return reviewCount > 0;
            }
        }

        public void MarkReservationDone(string reservationID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Reservation SET r_status = 1 WHERE reservationid = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", reservationID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
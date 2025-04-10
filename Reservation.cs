using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{


        class Reservation
    {
        private string CustomerID, ReservationID, HallID,category;
        private int  NumberOfPeople;
        private DateTime Eventdate;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string CustomerID1 { get => CustomerID; set => CustomerID=value; }
        
        public string ReservationID1 { get => ReservationID; set => ReservationID=value; }
        
        public int NumberOfPeople1 { get => NumberOfPeople; set => NumberOfPeople=value; }
        public string  HallID1 { get => HallID; set => HallID=value; }
        public DateTime Eventdate1 { get => Eventdate; set => Eventdate=value; }
        public string Category { get => category; set => category=value; }

        public Reservation(string custID, string reservID, string ctgry, int NumPpl, string hlID, DateTime dte)
        {
            CustomerID1 = custID;
            ReservationID1 = reservID;
            NumberOfPeople1 = NumPpl;
            HallID1 = hlID;
            Eventdate1 = dte;
            Category = ctgry;
        }
        public Reservation(int Num)
        {
            NumberOfPeople1 = Num;
        }
        public Reservation()
        {

        }

        public static ArrayList LoadHall(int num)
        {
            ArrayList hallIds = new ArrayList();

            try
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT hallid FROM hall WHERE h_capacity >= @Guests", con))
                {
                    command.Parameters.AddWithValue("@Guests", num);

                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            hallIds.Add(rd.GetString(0));
                        }
                    }
                }
                
            }
            catch (SqlException sqlEx)
            {
                
                MessageBox.Show("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return hallIds;
        }
        public string ADDRESERVATION(string CustID, string reservID, string Type, int numPeople, string location, DateTime dte)
        {
            string status;
            try
            {
                con.Open();

                SqlCommand command = new SqlCommand("INSERT INTO reservation (reservationid, customerId, hallId, r_date, r_numpeople, r_category) " +
                                "VALUES (@rsvID, @custoid, @hllid, @date, @numppl, @ctgry)", con);
                command.Parameters.AddWithValue("@rsvID", reservID);
                command.Parameters.AddWithValue("@custoid", CustID);
                command.Parameters.AddWithValue("@hllid", location);
                command.Parameters.AddWithValue("@date", dte);
                command.Parameters.AddWithValue("@numppl", numPeople);
                command.Parameters.AddWithValue("@ctgry", Type);
               
                int i = command.ExecuteNonQuery();
                status = i != 0 ? "Reservation saved successfully!" : "Reservation can't be made";

            }
            catch (SqlException sqlEx)
            {

                status = "An error occurred while adding the reservation: " + sqlEx.Message;
            }
            catch (Exception ex)
            {

                status = "An unexpected error occurred: " + ex.Message;
            }
            finally
            {

                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            MessageBox.Show(status);
            return status;
        }
        public bool checkcustomerID(string ID)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("select customerid from customer where customerid = @ID_Code", con);
            cmd.Parameters.AddWithValue("@ID_Code", ID);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }

        public bool checkreservationID(string ID)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("select reservationId from reservation where reservationId = @ID_Code", con);
            cmd.Parameters.AddWithValue("@ID_Code", ID);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }

        public DataTable Displayreservation(string reservationid)
        {

            DataTable resultDataTable = new DataTable();

            try
            {
                con.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT reservationid, customerid, hallid, r_date, r_numpeople, r_category FROM reservation WHERE reservationid = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", reservationid);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        adapter.Fill(resultDataTable);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("An unexpected exception occurred: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected exception occurred: " + ex.Message);
                throw;
            }
            finally
            {

                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return resultDataTable;
        }
        public DataTable Displayallreservation()
        {

            DataTable resultDataTable = new DataTable();

            try
            {
                con.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT reservationid, customerid, hallid, r_date, r_numpeople, r_category FROM reservation", con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        adapter.Fill(resultDataTable);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("An unexpected exception occurred: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected exception occurred: " + ex.Message);
                throw;
            }
            finally
            {

                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return resultDataTable;
        }

        public static ArrayList LoadReservation()
        {
            ArrayList reservationid = new ArrayList();

            try
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT reservationid FROM reservation", con))
                {
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            reservationid.Add(rd.GetString(0));
                        }
                    }
                }

            }
            catch (SqlException sqlEx)
            {

                MessageBox.Show("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return reservationid;
        }

        public string UPDATERESERVATION(string CustID, string reservID, string Type, int numPeople, string location, DateTime dte)
        {
            string status;
            try
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE reservation SET customerId = @custoid, hallId = @hllid, r_date = @date, r_numpeople = @numppl, r_category = @ctgry WHERE reservationid = @rsvID", con))
                {
                    command.Parameters.AddWithValue("@rsvID", reservID);
                    command.Parameters.AddWithValue("@custoid", CustID);
                    command.Parameters.AddWithValue("@hllid", location);
                    command.Parameters.AddWithValue("@date", dte);
                    command.Parameters.AddWithValue("@numppl", numPeople);
                    command.Parameters.AddWithValue("@ctgry", Type);

                    int i = command.ExecuteNonQuery();
                    status = i != 0 ? "Reservation updated successfully!" : "Reservation update failed";
                }
                
            }
            catch (SqlException sqlEx)
            {
                status = "An error occurred while updating the reservation: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                status = "An unexpected error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(status);
            return status;
        }

        public string DeleteReservation(string ID)
        {
            string status;
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                // User chose not to delete
                return "Deletion canceled.";
            }
            else
            {
                con.Open();
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM reservation WHERE reservationid  = @ID", con);
                    command.Parameters.AddWithValue("@ID", ID);

                    int rowsAffected = command.ExecuteNonQuery();
                    status = rowsAffected > 0 ? "Deletion Successful" : "No records deleted";

                }
                catch (SqlException sqlEx)
                {

                    MessageBox.Show("SQL Exception occurred: " + sqlEx.Message);
                    status = "An error occurred while deleting the reservation. Please try again.";
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An unexpected exception occurred: " + ex.Message);
                    status = "An unexpected error occurred. Please try again.";
                }
                finally
                {

                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                MessageBox.Show(status);
                return status;
            }
        }

        public bool checkHallAndDate(string ID, DateTime dte)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT hallid, r_date FROM reservation WHERE hallid = @ID_Code AND r_date = @rsvdatee", con);
            cmd.Parameters.AddWithValue("@ID_Code", ID);
            cmd.Parameters.AddWithValue("@rsvdatee", dte);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                check = true;

            }
            else
            {
                check = false;

            }
            con.Close();
            return check;
        }
    }
}

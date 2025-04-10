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
    internal class MenuItems
    {
        private string dishName, dishId, category, description;
        private int price;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());

        public string DishName { get => dishName; set => dishName=value; }
        public string DishId { get => dishId; set => dishId=value; }
        public string Category { get => category; set => category=value; }
        public string Description { get => description; set => description=value; }
        public int Price { get => price; set => price=value; }

        public MenuItems()
        {

        }
        public bool checkDishID(string ID)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("select menuId from menu where menuId= @ID_Code", con);
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

        public bool checkDishName(string Name)
        {
            bool check;
            con.Open();
            SqlCommand cmd = new SqlCommand("select m_name from menu where m_name= @dsh_name", con);
            cmd.Parameters.AddWithValue("@dsh_name", Name);

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

        public string AddDish(string menuID, string menuName, string category, double priice, string description)
        {
            string status;
            try
            {
                con.Open();

                string query = "INSERT INTO menu (menuId, m_name, m_category, m_description, m_price) " +
                                "VALUES (@mnID, @name, @category, @description, @price)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@mnID", menuID);
                    command.Parameters.AddWithValue("@name", menuName);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@price", priice);

                    int i = command.ExecuteNonQuery();
                    status = i != 0 ? "Dish saved successfully!" : "Dish can't be added";
                }

            }
            catch (SqlException sqlEx)
            {
                status = "An error occurred while adding the dish: " + sqlEx.Message;
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

        public static ArrayList LoadDish()
        {
            ArrayList menuid = new ArrayList();

            try
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT menuId FROM menu", con))
                {
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            menuid.Add(rd.GetString(0));
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

            return menuid;
        }

        public DataTable Displaymenu(string menuid)
        {

            DataTable resultDataTable = new DataTable();

            try
            {
                con.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT menuId, m_name, m_category, m_description, m_price FROM menu WHERE menuId = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", menuid);

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

        public string Deletemenu(string ID)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                // User chose not to delete
                return "Deletion canceled.";
            }
            else
            {
                string status;
                con.Open();
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM menu WHERE menuId  = @ID", con);
                    command.Parameters.AddWithValue("@ID", ID);

                    int rowsAffected = command.ExecuteNonQuery();
                    status = rowsAffected > 0 ? "Deletion Successful" : "No records deleted";

                }
                catch (SqlException sqlEx)
                {

                    MessageBox.Show("SQL Exception occurred: " + sqlEx.Message);
                    status = "An error occurred while deleting the dish. Please try again.";
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

        public DataTable DisplayallItems()
        {

            DataTable resultDataTable = new DataTable();

            try
            {
                con.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT menuId, m_name, m_category, m_description, m_price FROM menu", con))
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


        public string UpdateDish(string menuID, string menuName, string category, double pricee, string description)
        {
           

            string status;
            try
            {
                con.Open();

                string query = "UPDATE menu SET m_name = @name, m_category = @category, " +
                                "m_description = @description, m_price = @price WHERE menuId = @mnID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@mnID", menuID);
                    command.Parameters.AddWithValue("@name", menuName);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@price", pricee);

                    int rowsAffected = command.ExecuteNonQuery();
                    status = rowsAffected > 0 ? "Dish updated successfully!" : "Dish update failed.";
                }
            }
            catch (SqlException sqlEx)
            {
                status = "An error occurred while updating the dish: " + sqlEx.Message;
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


    }


}

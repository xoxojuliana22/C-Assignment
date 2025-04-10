using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Form11 : Form
    {
        int NumPeople;
        string reservid, custid, caategory, loocation;
        DateTime datee;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public Form11()
        {
            InitializeComponent();
            people.Leave += people_Leave;
            reservtxt.Leave +=  reservtxt_Leave;
            Reservation rsv = new Reservation();
            dataGridView1.DataSource = rsv.Displayallreservation();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(reservtxt.Text == "" || custID.Text == "" || category.Text == "" || dateTimePicker1.Value == DateTime.Now || people.Text == "" || Location.Text == "")
            {
                MessageBox.Show("Please fill all the fields ");
            }
            else
            {
                Reservation rsv = new Reservation();
                if(rsv.checkHallAndDate(loocation, datee) == true)
                {
                    MessageBox.Show("This hall is already booked for that date. Please chose another one.");
                }
                else
                {
                    rsv.UPDATERESERVATION(custid, reservid, caategory, NumPeople, loocation, datee);
                }
              
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservationMenu form9 = new ReservationMenu();
            form9.Show();
            this.Hide();
        }

        private void reservationtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            caategory = category.Text;
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
        private void LoadData(string reservationId)
        {

            try
            {
                con.Open();
                string query = "SELECT reservationid, customerid, hallid, r_category, r_numpeople, r_date FROM reservation WHERE reservationid = @reservationId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@reservationId", reservationId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        reservtxt.Text = reader["reservationid"].ToString();
                        custID.Text = reader["customerid"].ToString();
                        Location.Text = reader["hallid"].ToString();
                        category.Text = reader["r_category"].ToString();
                        people.Text = reader["r_numpeople"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["r_date"]);
                    }
                    else
                    {
                        MessageBox.Show("No data found for the provided reservation ID.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                people.Focus();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void reservtxt_TextChanged(object sender, EventArgs e)
        {
            reservid = reservtxt.Text;
        }

        private void custID_TextChanged(object sender, EventArgs e)
        {
            custid = custID.Text;   
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            datee = dateTimePicker1.Value;
        }

        private void Location_SelectedIndexChanged(object sender, EventArgs e)
        {
            loocation = Location.Text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reservtxt_Leave(object sender, EventArgs e)
        {
            Reservation rsv = new Reservation();
            rsv.checkreservationID(reservtxt.Text);
            if(rsv.checkreservationID(reservtxt.Text) == true)
            {
                LoadData(reservtxt.Text);
                reservtxt.ReadOnly = true;
                custID.ReadOnly = true;
               
            }
            else
            {
                MessageBox.Show("Reservation ID not found. Please Re enter.");
            }

        }

        private void people_TextChanged(object sender, EventArgs e)
        {
            if (people.Text == "")
            {
                Location.Items.Clear();
            }
        }
        private void people_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(people.Text, out NumPeople))
            {
                ArrayList Hall = new ArrayList();
                Hall = Reservation.LoadHall(NumPeople);
                foreach (var item in Hall)
                {
                    Location.Items.Add(item);
                }
            }
            else if (people.Text == "")
            {
                MessageBox.Show("Please fill the textbox");
                Location.Items.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a number.");
                people.Clear();
            }
        }
    }
}

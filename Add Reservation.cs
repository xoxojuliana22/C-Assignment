using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IOOP_Assignment
{

    public partial class Form10 : Form
    {
        string customerID, reservationID, hall, caategory;
        int NumPeople;
        DateTime RsvDate;
        public Form10()
        {
            InitializeComponent();
            custID.Leave += name_Leave;
            people.Leave += people_Leave;
            reservtxt.Leave +=  reservtxt_Leave;
           

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }
        static bool alphanumeric(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z0-9]*$");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (custID.Text == "" || reservtxt.Text == "" || category.Text == "" || people.Text == "" || Location.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                Reservation rsv = new Reservation();
                if(rsv.checkHallAndDate(hall,RsvDate) == true)
                {
                    MessageBox.Show("This hall is already booked for that date, please select another one.");
                }
                else
                {
                    rsv.ADDRESERVATION(customerID, reservationID, caategory, NumPeople, hall, RsvDate.Date);
                }
              

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void name_Leave(object sender, EventArgs e)
        {
            Reservation rsv = new Reservation();
            if (alphanumeric(custID.Text) == true || ValidateWhitespaceInput(custID.Text))
            {
                rsv.checkcustomerID(custID.Text);
                if (rsv.checkcustomerID(custID.Text) == true)
                {
                    MessageBox.Show("ID found!");
                    customerID = custID.Text;
                }
                else
                {
                    MessageBox.Show("ID not found please re enter.");
                    custID.Clear();
                }

            }
            else if (custID.Text == "")
            {

            }
            else
            {
                MessageBox.Show("Invalid customerid please re enter. Make sure id contains letters and digits only.");
                custID.Clear();
            }
        }




        private bool ValidateWhitespaceInput(string input)
        {
            Regex regex = new Regex("^[\\s]+$");
            return regex.IsMatch(input);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
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


        private void button2_Click(object sender, EventArgs e)
        {
            ReservationMenu form9 = new ReservationMenu();
            form9.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hall = Location.Text.ToString();

        }

        private void reservtxt_TextChanged(object sender, EventArgs e)
        {

        }
        private void reservtxt_Leave(object sender, EventArgs e)
        {
            if (alphanumeric(reservtxt.Text) == true && reservtxt.Text.Length == 5)
            {
                Reservation rsv1 = new Reservation();
                if (rsv1.checkreservationID(reservtxt.Text) == true)
                {
                    MessageBox.Show("A reservation with this reservation ID already exist Please re enter.");
                    reservtxt.Clear();
                }
                else
                {
                    reservationID = reservtxt.Text;
                }
            }
            else
            {
                MessageBox.Show("Please make sure that the reservationID has only 5 characters made of letters and digits only");
            }

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            caategory = category.Text.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            RsvDate = selectedDate.Date;
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        private void Form10_Load(object sender, EventArgs e)
        {

        }
        
    }
}

    


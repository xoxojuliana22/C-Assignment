using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class Form12 : Form
    {
        string reservationId;
        public Form12()
        {
            InitializeComponent();
            ArrayList rsvid = new ArrayList();
            rsvid = Reservation.LoadReservation();
            foreach (var item in rsvid)
            {
                category.Items.Add(item);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservationMenu form9 = new ReservationMenu(); 
            form9.ShowDialog();
            this.Hide();
        }

        private void reservtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

            Reservation rsv = new Reservation();
            reservationId =category.Text;
            dataGridView1.DataSource = rsv.Displayreservation(reservationId);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

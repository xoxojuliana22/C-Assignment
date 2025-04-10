using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class DeleteReservation : Form
    {
        string reservationId;
        public DeleteReservation()
        {
            InitializeComponent();
            ArrayList rsvid = new ArrayList();
            rsvid = Reservation.LoadReservation();
            foreach (var item in rsvid)
            {
                category.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Reservation rsv = new Reservation();
            rsv.DeleteReservation(reservationId);
            ReservationMenu form9 = new ReservationMenu();
            form9.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservationMenu form9 = new ReservationMenu();
            form9.Show();
            this.Hide();
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reservation rsv = new Reservation();
            reservationId =category.Text;
            dataGridView1.DataSource = rsv.Displayreservation(reservationId);
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}

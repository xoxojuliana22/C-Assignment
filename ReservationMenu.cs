using System;
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
    public partial class ReservationMenu : Form
    {
        public ReservationMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();  
            form12.Show();
            this.Hide();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteReservation form13 = new DeleteReservation();
            form13.Show();
            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            managerprofile form2 = new managerprofile();
            form2.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace IOOP_Assignment
{
    public partial class chefMain : Form
    {
        public string chefId { get; set; }
        public chefMain()
        {
            InitializeComponent();
            chefId = "ACF001";
        }

        /*private void chefMain_Load(object sender, EventArgs e)
        {

        }*/


        // this one we can get rid of
        /*private void btnAvailableOrders_Click(object sender, EventArgs e)
        {
            viewAvailableOrders viewAvailableOrders = new viewAvailableOrders(); //passing current instance of the first form
            viewAvailableOrders.Show();
            this.Hide();

        }*/



        private void btnChosenOrders_Click(object sender, EventArgs e)
        {
            chosenOrder chosenOrder = new chosenOrder();
            chosenOrder.Show();
            this.Hide();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            viewInventory viewInventory = new viewInventory();
            viewInventory.Show();
            this.Hide();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            chefUpdateProfile chefUpdateProfile = new chefUpdateProfile();
            chefUpdateProfile.Show();
            this.Hide();
        }
    }
}

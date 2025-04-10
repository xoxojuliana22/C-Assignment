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
    public partial class MenuOptions : Form
    {
        public MenuOptions()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            managerprofile form2 = new managerprofile();  
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewMenu form5 = new ViewMenu();
            form5.Show();
            this.Hide();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            description form6 = new description();
            form6.Show();
            this.Hide();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditMenu form7 = new EditMenu();
            form7.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete form8 = new delete();
            form8.Show();
            this.Hide();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

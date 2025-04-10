using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    
    public partial class InformationProfile : Form
    {
        public InformationProfile()
        {
            InitializeComponent();
            managerId.Leave += managerId_Leave;
        }
        static bool alphanumeric(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z0-9]*$");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProfileManager mp = new ProfileManager();
            if (mp.checkProfile(managerId.Text, passcode.Text) == true)
            {
                ManagerUpdateProfile updateProfile = new ManagerUpdateProfile();
                updateProfile.LoadData(managerId.Text, passcode.Text);
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong information inputted. Please try again");
                managerId.Clear();
                passcode.Clear();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void managerId_Leave(object sender, EventArgs e)
        {
            if(alphanumeric(managerId.Text) && managerId.Text.Length == 5)
            {

            }
            else
            {
                MessageBox.Show("Invalid ID. Make sure ID has 5 characters, with letters and digits only.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            managerprofile form2 = new managerprofile();
            form2.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InformationProfile_Load(object sender, EventArgs e)
        {

        }
    }
}

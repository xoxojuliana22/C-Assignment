using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IOOP_Assignment
{
    public partial class UpdateProfile : Form
    {
        int number;
       
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
    
       
        public UpdateProfile() 
        {
            InitializeComponent();
            idcode.ReadOnly = true;
            Pnum.Leave += Pnum_Leave;
            mail.Leave += mail_Leave;
            idcode.Focus();
            Pnum.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerProfile mp = new ManagerProfile();
            mp.UpdateProfile(idcode.Text, mail.Text, password.Text, number);
            managerprofile form2 = new managerprofile();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            managerprofile form2 = new managerprofile();
            form2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void m_name_TextChanged(object sender, EventArgs e)
        {

        }


        private void m_email_TextChanged(object sender, EventArgs e)
        {
          
        }

        private bool ValidateEmail(string email)
        {
            // Regular expression pattern to validate an email address
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        private void mail_Leave(object sender, EventArgs e)
        {
            if(ValidateEmail(mail.Text) == true)
            {
                ManagerProfile mp = new ManagerProfile();
                mp.checkEmail(mail.Text);
                if(mp.checkEmail(mail.Text) == true && mp.checkEmailid(idcode.Text, mail.Text) == true)
                {
                   
                }
                else if(mp.checkEmail(mail.Text) == true && mp.checkEmailid(idcode.Text, mail.Text) == false)
                {
                    MessageBox.Show("Email address already taken. Please re-enter.");
                    mail.Clear();
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please enter a valid email address.");
                mail.Clear();
            }
        }

        private void m_num_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Pnum_Leave(object sender, EventArgs e)
        {
            if(int.TryParse(Pnum.Text, out number))
            {
                number = int.Parse(Pnum.Text);
                ManagerProfile mp = new ManagerProfile();
                if(mp.checknum(number) == true && mp.checknumID(idcode.Text, number) == false)
                {
                    MessageBox.Show("Phone Number already taken. Please re-enter.");
                    Pnum.Clear();
                }
                else if(mp.checknum(number) == true && mp.checknumID(idcode.Text, number) == true)
                {

                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Please enter a valid phone number.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void UpdateProfile_Load(object sender, EventArgs e)
        {

        }
       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void LoadData(string managerId, string pass)
        {
            try
            {
                con.Open();
                string query = "SELECT m_email, m_password, m_num FROM manager WHERE managerid = @managerId and m_password = @passcode";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@managerId", managerId);
                cmd.Parameters.AddWithValue("@passcode", pass);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming m_email, m_num, and password are TextBox controls
                        mail.Text = reader["m_email"].ToString();
                        Pnum.Text = reader["m_num"].ToString();
                        password.Text = reader["m_password"].ToString();
                        idcode.Text = managerId;
                    }
                    else
                    {
                        MessageBox.Show("No data found for the provided manager ID and password.");
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
            }
           
        }

    }
}

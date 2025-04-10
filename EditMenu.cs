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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IOOP_Assignment
{
    public partial class EditMenu : Form
    {
        string dshname, dshcategory, dshdescription;
        double dshprice;
        string ID;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public EditMenu()
        {
            InitializeComponent();
            
            name.Leave += name_Leave;
            price.Leave += price_Leave;
            ArrayList menuid = new ArrayList();
            menuid = MenuItems.LoadDish();
            foreach (var item in menuid)
            {
                dishIDS.Items.Add(item);
            }
            

        }



        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private bool ValidateTextWithWhitespaces(string input)
        {
            // Regex to allow letters, digits, and whitespaces but ensure there is at least one non-whitespace character
            Regex regex = new Regex(@"^(?=.*\S)[a-zA-Z0-9\s]*$");
            return regex.IsMatch(input);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private bool ValidateInput(string input)
        {
            Regex regex = new Regex("^[a-zA-Z\\s]+$");
            return regex.IsMatch(input);
        }

        private void dishIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID = dishIDS.Text;
            LoadData(ID);
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            dshname = name.Text;
        }

        private void EditMenu_Load(object sender, EventArgs e)
        {

        }
        static bool alphanumeric(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z0-9]*$");
        }

        private bool ValidateWhitespaceInput(string input)
        {
            Regex regex = new Regex("^[\\s]+$");
            return regex.IsMatch(input);
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            dshcategory = category.Text;
        }

        private void price_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadData(string menuId)
        {


            try
            {
                con.Open();
                string query = "SELECT menuId, m_name, m_category, m_description, m_price FROM menu WHERE menuId = @menuId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@menuId", menuId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        dishIDS.Text = reader["menuId"].ToString();
                        name.Text = reader["m_name"].ToString();
                        category.Text = reader["m_category"].ToString();
                        descriptiontxt.Text = reader["m_description"].ToString();
                        price.Text = reader["m_price"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No data found for the provided dish ID.");
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
                price.Focus();
                con.Close();
            }

        }

        private void descriptiontxt_TextChanged(object sender, EventArgs e)
        {
            dshdescription = descriptiontxt.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(dishIDS.Text == "" || name.Text == "" || category.Text == "" || price.Text == "" || descriptiontxt.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                ID = dishIDS.Text;
                MenuItems dsh = new MenuItems();
                dsh.UpdateDish(ID, dshname, dshcategory, dshprice, dshdescription);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuOptions form4 = new MenuOptions();
            form4.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (alphanumeric(name.Text) == true || ValidateTextWithWhitespaces(name.Text))
            {
                dshname = name.Text;
            }
            else
            {
                MessageBox.Show("Make sure dish name contains letters and numbers only.");
            }
        }
        private void price_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(price.Text, out dshprice))
            {
                dshprice = double.Parse(price.Text);
            }
            else
            {
                MessageBox.Show("Please enter a digit value for price");
                price.Clear();
            }
        }
    }
}
